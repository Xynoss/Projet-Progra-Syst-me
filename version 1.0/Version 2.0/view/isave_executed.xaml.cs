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
    /// Logique d'interaction pour isave_executed.xaml
    /// </summary>
    public partial class isave_executed : Window
    {
        public isave_executed()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new MainWindow { Owner = this };
            window.Show();
            window.Close();
        }
    }
}
