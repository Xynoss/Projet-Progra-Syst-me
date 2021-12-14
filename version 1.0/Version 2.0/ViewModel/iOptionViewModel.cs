using System.Collections.Generic;
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


        private void DoCreateList()
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
            Encrypt.SetExtensions();
        }

        public void SetToEncryptExt(List<Encrypt> l_encrypts )
        {
            
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
