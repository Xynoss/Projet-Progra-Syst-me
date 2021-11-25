using System;
using System.IO;

namespace EasySave_1_0.model
{
    public class ModelDifferentialSave : ModelSave
    {
        public ModelDifferentialSave(string name, string sourcePath, string targetPath) : base(name, sourcePath, targetPath)
        {
        }

        /// <summary>
        /// methods to copy the files  
        /// </summary>
        public override void Save(ref model.ModelLogState state)
        {
            try
            {
                string[] fileList = Directory.GetFiles(sourcePath, "*");
                foreach (string f in fileList)
                {
                    filename = f.Substring(sourcePath.Length + 1);
                    File.Copy(Path.Combine(sourcePath, filename), Path.Combine(targetPath, filename));
                }

            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }
        }

        public override void LogLog(string name, TimeSpan span, string filename, string targetPath, string sourcePath)
        {
            string log_name = this.name;
            DateTime log_timestamp = DateTime.Now;
            //model.ModelLogState.GetInstance(log_name, this.sourcePath, this.targetPath, log_timestamp);
        }

        public override void LogState(string name, string fileSource, string fileTarget, string state)
        {
            string log_name = this.name;
            DateTime log_timestamp = DateTime.Now;
            //model.ModelLogLog log_save = model.ModelLogLog.GetInstance(log_name, filename, this.sourcePath, this.targetPath, log_timestamp);
            //log_save.WriteLog();
        }

    }

}
