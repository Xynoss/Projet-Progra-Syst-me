using System;
using System.IO;

namespace EasySave_1_0.model
{
    public class ModelLogLog : ModelLog
    {
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
        /// Constructor of the ModelLogLog class
        /// </summary>
        /// <param name="name">name of the save</param>
        /// <param name="filename">name of the file</param>
        /// <param name="fileSource">source path of the file</param>
        /// <param name="fileTarget">target path of the file</param>
        /// <param name="span">timeTransfert</param>
        public ModelLogLog(string name, string filename, string fileSource, string fileTarget, TimeSpan span) : base(name, fileSource, fileTarget)
        {
            Calcul_Check CnC = new Calcul_Check();
            this.filename = filename;
            this.fileSize = CnC.FileSize(filename);
            this.timeTransfert = (int)span.TotalMilliseconds;
        }
    }
}
