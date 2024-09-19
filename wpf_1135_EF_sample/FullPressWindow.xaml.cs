using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace wpf_1135_EF_sample
{
    public partial class FullPressWindow : Window
    {
        public YellowPress SelectedPress {  get; set; }
        public FullPressWindow(YellowPress selectedPress)
        {
            InitializeComponent();
            DataContext = this;

            SelectedPress = selectedPress;
        }
    }
}
