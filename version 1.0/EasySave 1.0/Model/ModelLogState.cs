using System;
using System.IO;

namespace EasySave_1_0.model
{
    public class ModelLogState : ModelLog
    {
        private string state;
        public string State {
            get
            {
                return state;
            }
            set
            {
                state = value;
            }
        }
        private int totalFileToCopy;
        public int TotalFileToCopy
        {
            get
            {
                return totalFileToCopy;
            }
            set
            {
                totalFileToCopy = value;
            }
        }
        private int totalFileSize;
        public int TotalFileSize
        {
            get
            {
                return totalFileSize;
            }
            set
            {
                totalFileSize = value;
            }
        }
        private int progression;
        public int Progression
        {
            get
            {
                return progression;
            }
            set
            {
                progression = value;
            }
        }
        private int nbFilesLeft;
        public int NbFilesLeft
        {
            get
            {
                return nbFilesLeft;
            }
            set
            {
                nbFilesLeft = value;
            }
        }
        public ModelLogState(string name, string fileSource, string fileTarget) : base(name, fileSource, fileTarget)
        {
            Calcul_Check CnC = new Calcul_Check();
            this.state = "";
            this.TotalFileToCopy = CnC.NbFiles(fileSource);
            this.TotalFileSize = CnC.FileSize(fileSource);
            //this.Progression = 0;
            this.NbFilesLeft = CnC.NbFiles(fileSource);
        }
    }

}
