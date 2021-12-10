using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Version_20.model;

namespace Version_20.ViewModel
{
    public class ModelViewMainWindow : ViewModelBase
    {
        private ICommand command;
        private string name_btn_createBackup;
        private string name_btn_runBackup;
        private string name_btn_runAllBackup;
        private string name_btn_Leave;
        private List<ModelBackup> backup = new List<ModelBackup>();
        private ModelRessources ressources = new ModelRessources();

        public ViewModelBase CurrentViewModel { get; }

        public string Name_btn_createBackup
        {
            get { return name_btn_createBackup; }
            set
            {
                name_btn_createBackup = value;
                OnPropertyChanged("Name_btn_createBackup");
            }
        }

        public string Name_btn_runBackup
        {
            get { return name_btn_runBackup; }
            set
            {
                name_btn_runBackup = value;
                OnPropertyChanged("Name_btn_runBackup");
            }
        }

        public string Name_btn_runAllBackup
        {
            get { return name_btn_runAllBackup; }
            set
            {
                name_btn_runAllBackup = value;
                OnPropertyChanged("Name_btn_runAllBackup");
            }
        }

        public string Name_btn_Leave
        {
            get { return name_btn_Leave; }
            set
            {
                name_btn_Leave = value;
                OnPropertyChanged("Name_btn_Leave");
            }
        }

        public ICommand GetResCommand
        {
            get
            {
                if (command == null)
                {
                    command = new RelayCommand(param => DoCommand(), param => CanDoCommand);
                }
                return command;
            }
            private set { command = value; }
        }

        private void DoCommand() { }

        public ModelViewMainWindow()
        {
            CurrentViewModel = new HomePageViewModel();
            name_btn_createBackup = this.ressources.GetRessources("create_save_btn");
            name_btn_runBackup = this.ressources.GetRessources("run_save_btn");
            name_btn_runAllBackup = this.ressources.GetRessources("run_save_all_btn");
        }

        private bool CanDoCommand
        {
            get { return ressources != null; }
        }

        public List<ModelBackup> Backup { get => backup; set => backup = value; }

        #region INotifyPropertyChanged Members 
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            var propertyChangedEventArgs =
                new PropertyChangedEventArgs(propertyName);
            if (PropertyChanged != null)
            {
                PropertyChanged(this, propertyChangedEventArgs);
            }
        }
        #endregion
    }
}
