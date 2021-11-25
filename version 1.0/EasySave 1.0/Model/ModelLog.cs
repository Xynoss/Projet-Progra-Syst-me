using System;

namespace EasySave_1_0.model
{
    public abstract class ModelLog
    {
        protected string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        protected string pathLog;
        public string PathLog
        {
            get
            {
                return pathLog;
            }
            set
            {
                pathLog = value;
            }
        }

        protected string fileSource;
        public string FileSource
        {
            get
            {
                return fileSource;
            }
            set
            {
                fileSource = value;
            }
        }
        protected string fileTarget;
        public string FileTarget
        {
            get
            {
                return fileTarget;
            }
            set
            {
                fileTarget = value;
            }
        }
        protected DateTime timestamp;
        public DateTime Timestamp
        {
            get
            {
                return timestamp;
            }
            set
            {
                timestamp = value;
            }
        }
        /// <summary>
        /// Constructor of the ModelLog class
        /// </summary>
        /// <param name="name">name of the save</param>
        /// <param name="fileSource">source path of the file</param>
        /// <param name="fileTarget">target path of the file</param>
        /// <param name="timestamp">timestamp</param>
        public ModelLog(string name, string fileSource, string fileTarget, DateTime timestamp)
        {
            this.Name = name;
            this.fileSource = fileSource;
            this.fileTarget = fileTarget;
            this.timestamp = timestamp;
        }
        /// <summary>
        /// Abstract method to write a log file.
        /// </summary>
        /// <param name="file">name of the file which is concerned at the moment of the process.</param>
        public abstract void WriteLog(string file);

    }

}
