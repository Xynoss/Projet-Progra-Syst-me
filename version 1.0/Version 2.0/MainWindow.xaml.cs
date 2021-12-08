using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EasySave_1_0.Controller;
using EasySave_1_0.model;
using System.Resources;
using Version_2._0.model;

namespace Version_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<EasySave_1_0.model.ModelSave> saves;
        public List<EasySave_1_0.model.ModelSave> Saves
        {
            get
            {
                return saves;
            }
            set
            {
                saves = value;
            }
        }

        

        

        public MainWindow()
        {
            ModelViewMainWindow modelView = new ModelViewMainWindow();
            DataContext = modelView;
            InitializeComponent();
            
            LbxBackup.ItemsSource= Saves;
        }

        private void French_flag_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        /*private void Button_Click(object sender, RoutedEventArgs e)
        {

        }*/
    }
}
