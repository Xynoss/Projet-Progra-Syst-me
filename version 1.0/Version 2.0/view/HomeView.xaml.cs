using EasySave_1_0.model;
using System;
using System.Collections.Generic;
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
            try
            {
                if (Process.GetProcessesByName("Calculator").Length > 0) {
                    string m;
                    m = String.Format("DO U NO DA WAE OV {0}?", "Calculator") ;
                    throw new System.Exception(m);
                }
                foreach (ModelSave item in dgSaves.ItemsSource)
                {
                    if (((CheckBox)check_list.GetCellContent(item)).IsChecked == true)
                    {
                        ModelLogState state_tmp = viemmodelhome_save.States.FindAll(state => state.Name == item.Name).FindAll(state => state.FileSource == item.SourcePath).Find(state => state.FileTarget == item.TargetPath);
                        List<ModelLogState> fullListStates = viemmodelhome_save.States;
                        Thread _thread = new Thread(new ThreadStart(ToSave));

                    }
                    
                    
                }
            }
            catch(Exception ex)
            {
                popup_ex.IsOpen = true;
            }
            
            
        }
        public void btn_close(object sender, RoutedEventArgs e)
        {
            popup_ex.IsOpen = false;
        }

        public static void ToSave(ModelSave item, ModelLogState state_tmp, List<ModelLogState> fullListStates)
        {
            item.Save(ref state_tmp, ref fullListStates);
        }
    }
}
