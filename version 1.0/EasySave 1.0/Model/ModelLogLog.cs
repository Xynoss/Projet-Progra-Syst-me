using System;
using System.IO;

namespace EasySave_1_0.model
{
    public class ModelLogLog : ModelLog
    {
        private static EasySave_1_0.model.ModelLogLog _instance;
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

        private string filename;
        public string Filename
        {
            get
            {
                return filename;
            }
            set
            {
                filename = value;
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

        public override void CreateLogFile() { }

        public override void WriteLog()
        {
            //StreamWriter sw = new StreamWriter(pathLog + name + "_log.json");
            if (!File.Exists(string.Concat(pathLog, name, "_log.json")))
            {
                File.Create(string.Concat(pathLog, name, "_log.json"));
                File.AppendAllText(string.Concat(pathLog, name, "_log.json"), string.Concat("Log_", Name, "_", Timestamp));
            }
            //sw.WriteLine(this.name + "\n" + this.fileSource + this.filename + "\n" + this.fileTarget + "\n" + this.timestamp + "\n" + this.fileSize + "\n" + this.timeTransfert);
            File.AppendAllText(string.Concat(pathLog, name, "_log.json"), string.Concat(this.name, "\n",
                this.fileSource, this.filename, "\n",
                this.fileTarget, "\n",
                this.timestamp, "\n",
                this.fileSize, "\n",
                this.timeTransfert
                ));
        }
        private ModelLogLog(string name, string filename, string fileSource, string fileTarget, DateTime timestamp) : base(name, fileSource, fileTarget, timestamp)
        {
            Calcul_Check CnC = new Calcul_Check();
            this.name = name;
            this.fileSource = fileSource;
            this.fileTarget = fileTarget;
            this.timestamp = timestamp;
            this.filename = filename;
            this.fileSize = CnC.FileSize(fileSource + filename); //calcul & check 
            this.timeTransfert = 0; //calcul & check
            this.pathLog = @"..\..\..\..\..\Log\";
        }
        public static EasySave_1_0.model.ModelLogLog GetInstance(string inst_name, string inst_filename, string inst_fileSource, string inst_fileTarget, DateTime inst_timestamp)
        {
            if (_instance == null)
            {
                _instance = new ModelLogLog(inst_name, inst_filename, inst_fileSource, inst_fileTarget, inst_timestamp);
            }
            return _instance;
        }


    }

}
