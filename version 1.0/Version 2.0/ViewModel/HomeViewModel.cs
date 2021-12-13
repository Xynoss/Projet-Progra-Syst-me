using System.Collections.Generic;
using System.ComponentModel;

namespace Version_2._0.ViewModel
{
    public sealed class HomeViewModel : INotifyPropertyChanged
    {
        static HomeViewModel _instance;
        public string Title { get; } = "Home";

        public event PropertyChangedEventHandler PropertyChanged;

        public List<EasySave_1_0.model.ModelSave> saves;
        public List<EasySave_1_0.model.ModelSave> Saves
        {
            get
            {
                return saves;
            }
            set
            {
                saves = value;
                OnPropertyChanged("saves");
            }
        }

        private List<EasySave_1_0.model.ModelLogState> states;
        public List<EasySave_1_0.model.ModelLogState> States
        {
            get
            {
                return states;
            }
            set
            {
                states = value;
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            var propertyChangedEventArgs =
                new PropertyChangedEventArgs(propertyName);
            if (PropertyChanged != null)
            {
                PropertyChanged(this, propertyChangedEventArgs);
            }
        }

        private HomeViewModel()
        {
            saves = new List<EasySave_1_0.model.ModelSave>();
            states = new List<EasySave_1_0.model.ModelLogState> { };
        }

        public static HomeViewModel getInstance()
        {
            if (_instance == null)
            {
                _instance = new HomeViewModel();
            }
            return _instance;
        }
    }
}
