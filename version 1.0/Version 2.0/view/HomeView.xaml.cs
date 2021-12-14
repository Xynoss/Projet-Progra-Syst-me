using EasySave_1_0.model;
using System.Collections.Generic;
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
            foreach (ModelSave item in dgSaves.ItemsSource)
            {
                if (((CheckBox)check_list.GetCellContent(item)).IsChecked == true)
                {
                    ModelLogState state_tmp = viemmodelhome_save.States.FindAll(state => state.Name == item.Name).FindAll(state => state.FileSource == item.SourcePath).Find(state => state.FileTarget == item.TargetPath);
                    List<ModelLogState> fullListStates = viemmodelhome_save.States;
                    item.Save(ref state_tmp,ref fullListStates);
                }
            }
        }
    }
}
