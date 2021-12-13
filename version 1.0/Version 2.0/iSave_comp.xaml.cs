using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Version_2._0
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class iSave_comp : Window
    {
        public iSave_comp()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow { Owner = this };
            window.Show();
            window.Close();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            var window = new iSave_comp { Owner = this };
            window.Close();
            var window2 = new iSave_diff { Owner = this };
            window2.Show();
        }
    }
}
