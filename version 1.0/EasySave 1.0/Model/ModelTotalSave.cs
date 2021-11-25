using System;
using System.IO;

namespace EasySave_1_0.model
{
    /// <summary>
    /// Class for the Total Save option.
    /// </summary>
    public class ModelTotalSave : ModelSave
    {
        public ModelTotalSave(string name, string sourcePath, string targetPath) : base(name, sourcePath, targetPath)
        {
        }
        /// <summary>
        /// Method to save in total save mode.
        /// </summary>
        public override void Save()
        {
            
            try
            {
                string[] fileList = Directory.GetFiles(sourcePath, "*");
                foreach (string f in fileList)
                {
                    filename = f.Substring(sourcePath.Length);
                    File.Copy(Path.Combine(sourcePath, filename), Path.Combine(targetPath, filename), true);
                    LogLog(filename);
                }
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }
                
        }
        /// <summary>
        /// Method to initialize the writing of the state's files
        /// </summary>
        public override void LogState()
        {
            string log_name = this.name;
            DateTime log_timestamp = DateTime.Now;
            model.ModelLogState.GetInstance(log_name, this.sourcePath, this.targetPath, log_timestamp);

        }
        /// <summary>
        /// Method to initialize the writing of the log's files.
        /// </summary>
        /// <param name="str_in">file concerned at the moment of the process.</param>
        public override void LogLog(string str_in)
        {
            string log_name = this.name;
            DateTime log_timestamp = DateTime.Now;
            model.ModelLogLog log_save = model.ModelLogLog.GetInstance(log_name, str_in, this.sourcePath, this.targetPath, log_timestamp);
            log_save.WriteLog(str_in);
        }

    }

}
