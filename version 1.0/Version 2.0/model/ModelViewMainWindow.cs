using System.ComponentModel;
using System.Windows.Input;

namespace Version_2._0.model
{
    public class ModelViewMainWindow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ICommand command;
        private string name_btn_createBackup;
        private ModelRessources ressources = new ModelRessources();
        
        public string Name
        {
            get { return name_btn_createBackup; }
            set { name_btn_createBackup = value; }
        }

        public ICommand GetResCommand { 
            get {
                if(command == null)
                {
                    command = new RelayCommand(param => DoCommand(),
                        param => CanDoCommand);
                }
                return command; 
            }
            private set { command = value; }
        }

        private void DoCommand()
        {
            name_btn_createBackup = ressources.GetRessources();
        }


        private bool CanDoCommand
        {
            get { return ressources != null; }
        }
    }
}
