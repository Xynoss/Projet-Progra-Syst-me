using EasySave_1_0.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;

namespace Version_2._0.ViewModel
{
    #region Singleton
    public sealed class HomeViewModel : INotifyPropertyChanged
    {
        #region attribut
        private ICommand commandpause;
        private ICommand commandplay;
        private ICommand commandstop;
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

        public ICommand GetPauseCommand
        {
            get
            {
                if(commandpause == null)
                {
                    commandpause = new RelayCommand(param => pause());
                }
                return commandpause;
            }
        }

        public ICommand GetStopCommand
        {
            get
            {
                if(commandstop == null)
                {
                    commandstop = new RelayCommand(param => stop());
                }
                return commandstop;
            }
        }

        public ICommand GetPlayCommand
        {
            get
            {
                if(commandplay == null)
                {
                    commandplay = new RelayCommand(param => play());
                }
                return commandplay;
            }
        }
        #endregion

        #region constructeur
        private HomeViewModel()
        {
            Logger _intenceLog = Logger.GetInstance();
            States = _intenceLog.JsonToSave();
            Saves = new List<ModelSave>();
            States.ForEach(x => Saves.Add(x.StateToSave()));
        }
        #endregion

        #region récup instance
        public static HomeViewModel getInstance()
        {
            if (_instance == null)
            {
                _instance = new HomeViewModel();
            }
            return _instance;
        }
        #endregion

        #region Méthode
        public void Saving(ModelLogState item)
        {
            ModelLogState tmp = States.FindAll(state => state.Name == item.Name).FindAll(state => state.FileSource == item.FileSource).Find(state => state.FileTarget == item.FileTarget);
            List<ModelLogState> l_states = States;
            ModelSave SaveToRun = item.StateToSave();
            SaveToRun.Save(ref tmp, ref l_states);
        }

        public void play()
        {
            ModelSave.mrevent.Set();
        }

        public void pause()
        {
            ModelSave.mrevent.Reset();
        }

        public void stop()
        {
            
        }
        #endregion
    }
    #endregion
}
