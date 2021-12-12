using EasySave_1_0.model;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Version_2._0.view
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class iSave_comp : UserControl
    {
        private static List<model.ModelLogState> states = new List<model.ModelLogState>();
        public static List<model.ModelLogState> States
        {
            get { return states; }
            set { states = value; }
        }

        public iSave_comp()
        {
            InitializeComponent();
        }


        private void OpenFileExplorer(TextBox textBox)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.ShowDialog();
            textBox.Text = dialog.SelectedPath;
        }

        private void Btn_Save(object sender, RoutedEventArgs e)
        {
            ModelSave Save = new ModelTotalSave(Txtbox_save_name.Text,Txtbox_DosSource.Text,Txtbox_target.Text);
            ModelLogState toState = Save.ToState();
            Save.Save(ref toState);
        }

        private void Btn_SearchSource(object sender, RoutedEventArgs e)
        {
            OpenFileExplorer(tb_source);
        }

        private void Btn_SearchTarget(object sender, RoutedEventArgs e)
        {
            OpenFileExplorer(Txtbox_target);
        }

        private void display_SaveSource(object sender, RoutedEventArgs e)
        {
            Txtbox_Savesource.Visibility = Visibility.Visible;
            Txtbox_DosSource.Visibility = Visibility.Hidden;
        }
        private void display_DosSource(object sender, RoutedEventArgs e)
        {
            Txtbox_DosSource.Visibility = Visibility.Visible;
            Txtbox_Savesource.Visibility = Visibility.Hidden;
        }
    }
}
