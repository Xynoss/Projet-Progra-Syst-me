using EasySave_1_0.model;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using Version_2._0.ViewModel;

namespace Version_2._0.view
{
    /// <summary>
    /// Logique d'interaction pour HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        HomeViewModel viemmodelhome_save = HomeViewModel.getInstance();

        public HomeView()
        {
            HomeViewModel ViewModel = HomeViewModel.getInstance();
            DataContext = ViewModel;
            InitializeComponent();
        }

        public void btn_execute(object sender, RoutedEventArgs e)
        {
            
                /*try
                {

                    
                }
                catch (Exception ex)
                {
                    popup_ex.Dispatcher.Invoke(() =>
                    {
                        popup_ex.IsOpen = true;
                    });
                }*/
                foreach (ModelLogState item in dgSaves.ItemsSource)
                {
                    /*if (Process.GetProcessesByName("notepad").Length > 0)
                    {
                        string m;
                        m = String.Format("DO U NO DA WAE OV {0}?", "Calculator");
                        throw new System.Exception(m);
                    }*/

                    if (((CheckBox)check_list.GetCellContent(item)).IsChecked == true)
                    {
                        Thread _thread = new Thread(() =>
                        {
                        viemmodelhome_save.Saving(item);
                        });
                        _thread.Start();
                }
                }
            
            

        }
        public void btn_close(object sender, RoutedEventArgs e)
        {
            popup_ex.IsOpen = false;
        }
    }
}
