﻿using System;
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

namespace Version_2._0.view
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class iSave_comp : UserControl
    {
        public iSave_comp()
        {
            InitializeComponent();
            if(save_comp.IsChecked == true)
            {
                save_diff.IsChecked = false;
            }
            if (save_diff.IsChecked == true)
            {
                save_comp.IsChecked = false;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }

    }
}
