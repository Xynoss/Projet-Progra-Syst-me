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

        public ModelLog(string name, string fileSource, string fileTarget, DateTime timestamp)
        {
            this.Name = name;
            this.fileSource = fileSource;
            this.fileTarget = fileTarget;
            this.timestamp = timestamp;
        }

        public abstract void CreateLogFile();
        public abstract void WriteLog();

    }

}
