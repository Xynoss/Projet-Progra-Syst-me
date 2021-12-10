using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Version_20.model;
using Version_20.ViewModel;

namespace Version_20
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new ModelViewMainWindow()
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
