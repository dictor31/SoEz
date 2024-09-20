using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace wpf_1135_EF_sample
{
    /// <summary>
    /// Логика взаимодействия для PressWindow.xaml
    /// </summary>
    public partial class PressWindow : Window, INotifyPropertyChanged
    {
        private List<YellowPress> presses;
        public List<YellowPress> Presses
        {
            get => presses;
            set
            {
                presses = value;
                Signal();
            }
        }

        public YellowPress SelectedPress { get; set; }
        public PressWindow()
        {
            InitializeComponent();
            DataContext = this;

            Loaded += PressWindow_Loaded;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        void Signal([CallerMemberName] string prop = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        private void UpdateList()
        {
            using (var db = new _1135New2024Context())
            {
                Presses = db.YellowPresses
                    .Include(yp => yp.IdSingerNavigation)
                    .ToList();
            }
        }

        private void PressWindow_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateList();
        }

        private void Click_del(object sender, RoutedEventArgs e)
        {
            if (SelectedPress == null || MessageBox.Show("Are you sure?", "Confirm", MessageBoxButton.YesNo) == MessageBoxResult.No)
                return;

            using (var db = new _1135New2024Context())
            {
                db.YellowPresses.Remove(SelectedPress);
                db.SaveChanges();
            }

            UpdateList();
        }
        private void Double_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            FullPressWindow fullPress = new FullPressWindow(SelectedPress);
            fullPress.Show();
        }
    }
}
