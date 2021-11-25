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
        public override void Save(ref model.ModelLogState state)
        {
            
            try
            {
                string[] fileList = Directory.GetFiles(sourcePath, "*");
                foreach (string f in fileList)
                {
                    filename = f.Substring(sourcePath.Length);
                    DateTime start = DateTime.Now;
                    File.Copy(Path.Combine(sourcePath, filename), Path.Combine(targetPath, filename), true);
                    state.NbFilesLeft--;
                    TimeSpan span = DateTime.Now - start;
                    LogLog(name, span, f, targetPath, sourcePath);
                    LogState(state);
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
            Logger.GetInstance().WriteState(new ModelLogState(name, fileSource, fileTarget));
        }
        /// <summary>
        /// Method to initialize the writing of the log's files.
        /// </summary>
        public override void LogLog(string name, TimeSpan span, string filename, string targetPath, string sourcePath)
        {
            Logger.GetInstance().WriteLog(new ModelLogLog(name, filename, sourcePath, targetPath, span));
        }

    }

}
