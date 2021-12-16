using EasySave_1_0.model;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Version_2._0.ViewModel;
using System.Threading;
using System.ComponentModel;



namespace Version_2._0.view
{
    /// <summary>
    /// Logique d'interaction pour Window2.xaml
    /// </summary>
    public partial class CreateBackupView : UserControl
    {
        CreateBackupModelView Backuper;
        
        public CreateBackupView()
        {
            InitializeComponent();
            Backuper = new CreateBackupModelView();
        }


        private void OpenFileExplorer(TextBox textBox)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.ShowDialog();
            textBox.Text = dialog.SelectedPath;
        }

        private void Btn_Save(object sender, RoutedEventArgs e)
        {

            if(save_comp.IsChecked == true){
                Backuper.CreateComp(Txtbox_save_name.Text, tb_source.Text, Txtbox_target.Text);
            }
            if(save_diff.IsChecked == true)
            {
                Backuper.CreateDiff(Txtbox_save_name.Text, tb_source.Text, Txtbox_target.Text,tb_refSave.Text);
            }


            //



    
            BackgroundWorker worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;
            worker.RunWorkerCompleted += worker_RunWorkerCompleted;
            worker.RunWorkerAsync(10000);

        }

        // Declare our worker thread
        private Thread workerThread = null;

        // Boolean flag used to stop the 
        private bool stopProcess = false;

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (save_comp.IsChecked == true)
            {
                Backuper.CreateComp(Txtbox_save_name.Text, tb_source.Text, Txtbox_target.Text);
            }
            if (save_diff.IsChecked == true)
            {
                Backuper.CreateDiff(Txtbox_save_name.Text, tb_source.Text, Txtbox_target.Text, tb_refSave.Text);
            }
        }

        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Update UI
            this.txtProgress.Text += "  *";

        }

        void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                // An error occurred
                this.txtProgress.Text += Environment.NewLine + "An error occurred: " + e.Error.Message;
            }
            else if (e.Cancelled)
            {
                // The process was cancelled
                this.txtProgress.Text += Environment.NewLine + "Job cancelled.";
            }
            else
            {
                // The process finished
                this.txtProgress.Text += Environment.NewLine + "Job finished.";
            }
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
            tb_refSave.IsEnabled = true;
        }
        private void display_DosSource(object sender, RoutedEventArgs e)
        {
            Txtbox_DosSource.Visibility = Visibility.Visible;
            Txtbox_Savesource.Visibility = Visibility.Hidden;
            tb_refSave.IsEnabled = false;
        }

        

    }
}
