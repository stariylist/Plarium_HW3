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

namespace Plarium_HW3
{
  
    public partial class Random_Values : Window
    {
        public Random_Values()
        {
            InitializeComponent();
        }

        private void apply_rnd_values_Click(object sender, RoutedEventArgs e)//нажатие кнопки принять
        {
            Close();//закрываем окно)
        }
    }
}
