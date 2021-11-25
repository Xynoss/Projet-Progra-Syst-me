using System;
using System.IO;

namespace EasySave_1_0.model
{
    public class ModelLogLog : ModelLog
    {
        private static EasySave_1_0.model.ModelLogLog _instance;
        private uint fileSize;
        public uint FileSize
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
        /// <summary>
        /// Method to write a log file.
        /// </summary>
        /// <param name="file">name of the file which is concerned at the moment of the process.</param>
        public override void WriteLog(string file)
        {
            DateTime start = DateTime.Now;
            Calcul_Check CnC = new Calcul_Check();
            this.filename = file;
            this.fileSize = CnC.FileSize(fileSource + filename);
            TimeSpan span = DateTime.Now - start;
            this.timeTransfert = (int)span.TotalMilliseconds;
            File.AppendAllText(string.Concat(pathLog, name, "_log.json"), string.Concat("{", this.timestamp, "\n", "Name : ", this.name, "\n",
                "Source Path :", this.fileSource, this.filename, "\n",
                "Destination Path :", this.fileTarget, this.filename, "\n",
                "FileSize :", this.fileSize, "\n",
                "TimeTransfert :", this.timeTransfert, "\n}"
                ));
        }
        /// <summary>
        /// Constructor of the ModelLogLog class
        /// </summary>
        /// <param name="name">name of the save</param>
        /// <param name="filename">name of the file</param>
        /// <param name="fileSource">source path of the file</param>
        /// <param name="fileTarget">target path of the file</param>
        /// <param name="timestamp">timestamp</param>
        private ModelLogLog(string name, string filename, string fileSource, string fileTarget, DateTime timestamp) : base(name, fileSource, fileTarget, timestamp)
        {
            this.name = name;
            this.fileSource = fileSource;
            this.fileTarget = fileTarget;
            this.timestamp = timestamp;
            this.filename = filename;
            this.fileSize = 0;
            this.timeTransfert = 0;
            this.pathLog = @"..\..\..\..\..\Log\";
        }
        /// <summary>
        /// Method to return a existed instance or create a new one (SINGLETON)
        /// </summary>
        /// <param name="inst_name">name of the save</param>
        /// <param name="inst_filename">name of the file</param>
        /// <param name="inst_fileSource">source path of the file</param>
        /// <param name="inst_fileTarget">target path of the file</param>
        /// <param name="inst_timestamp">timestamp</param>
        /// <returns></returns>
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
