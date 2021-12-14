using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace Version_2._0.ViewModel
{
    class iOptionViewModel:INotifyPropertyChanged
    {
        private ICommand command;
        private bool pdf;
        private bool jpg;
        private bool docx;
        private bool txt;

        public bool Pdf
        {
            get => this.pdf;
            set
            {
                this.pdf = value;
                OnPropertyChanged("Pdf");
            }
        }
        public bool Jpg
        {
            get => this.jpg;
            set
            {
                this.jpg = value;
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
            if (jpg)
            {
                ExtToEnc.Add(".jpg");
            }
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
