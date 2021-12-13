using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Version_2._0
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            SetLanguageDictionary();
        }

        private void SetLanguageDictionary()
        {
            Version_2._0.Properties.Resources.Culture = new System.Globalization.CultureInfo(Version_2._0.Properties.Settings.Default.Lang);
            Version_2._0.Properties.Settings.Default.Lang = Version_2._0.Properties.Settings.Default.Lang;
            Version_2._0.Properties.Settings.Default.Save();
        }
    }
}
