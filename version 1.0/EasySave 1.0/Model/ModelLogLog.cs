using System;
using System.IO;

namespace EasySave_1_0.Model
{
    public class ModelLogLog : ModelLog
    {
        private static EasySave_1_0.Model.ModelLogLog _instance;
        private int fileSize;
        public int FileSize
        {
            get
            {
                return fileSize;
            }
            set
            {
                fileSize = value;
            }
        }

        private int timeTransfert;
        public int TimeTransfert
        {
            get
            {
                return timeTransfert;
            }
            set
            {
                timeTransfert = value;
            }
        }

        public override void CreateLogFile()
        {
            if (!File.Exists(string.Concat(pathLog, name, "_log.json")))
            {
                File.Create(string.Concat(pathLog, name, "_log.json"));
                File.AppendAllText(string.Concat(pathLog, name, "_log.json"), string.Concat("Log_", Name, "_", Timestamp));
            }
        }
        public override void WriteLog()
        {
            File.WriteAllText(string.Concat(pathLog, name, "_log.json"), string.Concat(""));
        }
        private ModelLogLog(string name, string fileSource, string fileTarget, DateTime timestamp) : base(name, fileSource, fileTarget, timestamp)
        {
            this.name = name;
            this.fileSource = fileSource;
            this.fileTarget = fileTarget;
            this.timestamp = timestamp;
            this.fileSize = 0; //calcul & check 
            this.timeTransfert = 0; //calcul & check
            this.pathLog = @"..\..\Log\";
        }
        public static EasySave_1_0.Model.ModelLogLog GetInstance(string inst_name, string inst_fileSource, string inst_fileTarget, DateTime inst_timestamp)
        {
            if (_instance == null)
            {
                _instance = new ModelLogLog(inst_name, inst_fileSource, inst_fileTarget, inst_timestamp);
            }
            return _instance;
        }


    }

}*/
