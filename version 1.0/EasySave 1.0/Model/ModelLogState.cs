using System;
using System.IO;

namespace EasySave_1_0.model
{
    public class ModelLogState : ModelLog
    {
        private static ModelLogState instance;
        private bool state;
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

        private string pathtoLog;
        public string PathtoLog
        {
            get { return pathtoLog; }
            set { pathtoLog = value; }
        }

        
        public override void CreateLogFile()
        {
            pathtoLog = string.Concat(pathLog, name, "_log_state.json");
            if (!File.Exists(pathtoLog))
            {
                File.Create(pathtoLog);
                File.AppendAllText(pathtoLog, string.Concat("Log_", Name, "_", Timestamp));
            };
        }
        public override void WriteLog()
        {

            File.WriteAllText(string.Concat(pathLog, name, "_log_state.json"), string.Concat(name, "\n", timestamp, "\n", nbFilesLeft, "\n", totalFileSize, "\n", totalFileToCopy, "\n", fileSource, "\n", fileTarget, "\n")); ;
        }
        private ModelLogState(string name, string fileSource, string fileTarget, DateTime timestamp) : base(name, fileSource, fileTarget, timestamp)
        {
            this.name = name;
            this.fileSource = fileSource;
            this.fileTarget = fileTarget;
            this.timestamp = timestamp;
            this.state = true;
            this.TotalFileToCopy = 0;
            this.TotalFileSize = 0;
            this.Progression = 0;
            this.NbFilesLeft = 0;
        }


        public static ModelLogState GetInstance(string inst_name, string inst_fileSource, string inst_fileTarget, DateTime inst_timestamp)
        {
            if (instance == null)
            {
                instance = new ModelLogState(inst_name, inst_fileSource, inst_fileTarget, inst_timestamp);
            }
            return instance;
        }



    }

}
