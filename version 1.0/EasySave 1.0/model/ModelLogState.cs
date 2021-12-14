using System;
using System.Collections.Generic;
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


        /// <summary>
        /// constructor of the modelLogState class
        /// </summary>
        /// <param name="name">name of the save</param>
        /// <param name="fileSource">source path of the file</param>
        /// <param name="fileTarget">target path of the file</param>
        public ModelLogState(string name, string fileSource, string fileTarget , string SaveType) : base(name, fileSource, fileTarget)
        {
            Calcul_Check CnC = new Calcul_Check();
            this.state = "";
            this.TotalFileToCopy = CnC.NbFiles(fileSource);
            this.TotalFileSize = CnC.FileSize(fileSource);
            //this.Progression = 0;
            this.NbFilesLeft = CnC.NbFiles(fileSource);
            this.SaveType = SaveType;
        }

        public ModelLogState(): base() { }

        public void StateToSave()
        {
            Logger _intenceLog = Logger.GetInstance();
            List<ModelLogState> State = _intenceLog.JsonToSave();
            ModelSave _modelsave;
            switch (this.SaveType)
            {
                case "Diff":
                    _modelsave = new ModelDifferentialSave(Name, FileSource, FileTarget, SaveRef);
                    break;
                case "Total":
                    _modelsave = new ModelTotalSave(Name, FileSource, FileTarget);
                    break;
            }
        }
    }

}
