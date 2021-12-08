using System.ComponentModel;
using System.Windows.Input;

namespace Version_2._0.model
{
    public class ModelViewMainWindow : INotifyPropertyChanged
    {
        private ICommand command;
        private string name_btn_createBackup;
        private string name_btn_runBackup;
        private ModelRessources ressources = new ModelRessources();

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

        public ICommand GetResCommand
        {
            get
            {
                if (command == null)
                {
                    command = new RelayCommand(param => DoCommand(),
                        param => CanDoCommand);
                }
                return command;
            }
            private set { command = value; }
        }

        private void DoCommand() { }

        public ModelViewMainWindow()
        {
            name_btn_createBackup = this.ressources.GetRessources("create_save_btn");
            name_btn_runBackup = this.ressources.GetRessources("run_save_btn");
        }


        private bool CanDoCommand
        {
            get { return ressources != null; }
        }

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
