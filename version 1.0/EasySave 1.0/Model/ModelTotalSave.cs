using System;
using System.Collections.Generic;
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
        /// methods to copy the files, trying to create the save and take every file form the source path.
        /// </summary>
        /// <param name="state">an object Log State to refer to</param>
        public override void Save(ref model.ModelLogState state)
        {

            try
            {
                DirectoryCreated();
                //search in the source path to compare with the saveref
                foreach (string f in fileList)
                {
                    filename = Path.GetFileName(f);
                    //Copy the file form the source to the target
                    CopyAndWrite(ref state, name, sourcePath, filename, targetPathSave, f);
                }
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }
            state.State = "END";
            LogState(Controller.Controller.States);
        }
        /// <summary>
        /// Method to initialize the writing of the log's states files.
        /// </summary>
        /// <param name="state">list of modelLogState object</param>
        public override void LogState(List<model.ModelLogState> state)
        {
            Logger.GetInstance().WriteState(state);
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

    }

}
