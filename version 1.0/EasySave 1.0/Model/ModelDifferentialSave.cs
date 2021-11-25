using System;
using System.Collections.Generic;
using System.IO;

namespace EasySave_1_0.model
{
    /// <summary>
    /// class to build a save but to save only the modification between the source and the target
    /// </summary>
    public class ModelDifferentialSave : ModelSave
    {
        public ModelDifferentialSave(string name, string sourcePath, string targetPath) : base(name, sourcePath, targetPath)
        {
        }

        /// <summary>
        /// methods to copy the files, trying to create the save and take every file form the source path.
        /// </summary>
        /// <param name="state">an object Log State to refer to</param>
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
        /// <summary>
        /// Method to initialize the writing of the log's files.
        /// </summary>
        /// <param name="name">name of the save.</param>
        /// <param name="span">time span form the start.</param>
        /// <param name="filename">name of the file.</param>
        /// <param name="targetPath">path to the target folder.</param>
        /// <param name="sourcePath">path to the source folder.</param>
        public override void LogLog(string name, TimeSpan span, string filename, string targetPath, string sourcePath)
        {
            Logger.GetInstance().WriteLog(new ModelLogLog(name, filename, sourcePath, targetPath, span));
        }
        /// <summary>
        /// Method to initialize the writing of the log's states files.
        /// </summary>
        /// <param name="state">list of modelLogState object</param>
        public override void LogState(List<model.ModelLogState> state)
        {
            Logger.GetInstance().WriteState(state);
        }

    }

}
