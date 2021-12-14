﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Version_2._0.model;
using Version_2._0.Properties;

namespace Version_2._0.ViewModel
{
    class iOptionViewModel : INotifyPropertyChanged
    {
        private ICommand command;
        static iOptionViewModel _instance;
        private bool pdf;
        private bool jpeg;
        private bool docx;
        private bool txt;

        public bool Pdf
        {
            get => pdf;
            set
            {
                pdf = value;
                OnPropertyChanged("Pdf");
            }
        }
        public bool Jpeg
        {
            get => this.jpeg;
            set
            {
                this.jpeg = value;
                OnPropertyChanged("Jpg");
            }
        }
        public bool Docx
        {
            get => this.docx;
            set
            {
                this.docx = value;
                OnPropertyChanged("Docx");
            }
        }
        public bool Txt
        {
            get => this.txt;
            set
            {
                this.txt = value;
                OnPropertyChanged("Txt");
            }
        }

        private iOptionViewModel() { }
        public static iOptionViewModel getInstance()
        {
            if (_instance == null)
            {
                _instance = new iOptionViewModel();
            }
            List<string> list_ext = Encrypt.ListExt;
            _instance.pdf = list_ext.Exists(val => val == "pdf");
            _instance.jpeg = list_ext.Exists(val => val == "jpeg");
            _instance.docx = list_ext.Exists(val => val == "docx");
            _instance.txt = list_ext.Exists(val => val == "txt");
            return _instance;
        }

        public ICommand GetSaveCommand
        {
            get
            {
                if (command == null)
                {
                    command = new RelayCommand(param => DoCreateList(),
                                               param => CanDoCommand);
                }
                return command;
            }
            private set { command = value; }
        }


        public void DoCreateList()
        {
            List<string> ExtToEnc = new List<string>();
            if (pdf)
            {
                ExtToEnc.Add(".pdf");
            }
            if (docx)
            {
                ExtToEnc.Add(".docx");
            }
            if (txt)
            {
                ExtToEnc.Add(".txt");
            }
            if (jpeg)
            {
                ExtToEnc.Add(".jpeg");
            }
            SetToEncryptExt(ExtToEnc);
            Encrypt.SetExtensions();
            
        }

        public void SetToEncryptExt(List<string> l_encrypts )
        {
            Settings.Default.exToEnc.Clear();
            foreach (string s in l_encrypts)
            {
                Settings.Default.exToEnc.Add(s);
            }
            Settings.Default.Save();
        }

        private bool CanDoCommand
        {
            get { return command != null; }
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
