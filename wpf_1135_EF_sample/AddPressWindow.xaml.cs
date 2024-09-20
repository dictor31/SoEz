using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace wpf_1135_EF_sample
{
    public partial class AddPressWindow : Window
    {
        public Singer Singer { get; set; }
        public YellowPress YellowPress { get; set; }
        public AddPressWindow(Singer singer)
        {
            InitializeComponent();
            Singer = singer;
            YellowPress = new YellowPress();
 
            DataContext = this;
        }

        private void Click_add(object sender, RoutedEventArgs e)
        {
            YellowPress.IdSinger = Singer.Id;
            using (var db = new _1135New2024Context())
            {
                db.YellowPresses.Add(YellowPress);
                db.SaveChanges();
            }
            Close();
        }
    }
}
