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
        private string saveRefPath;
        public string SaveRefPath
        {
            get { return saveRefPath; }
            set { saveRefPath = value; }
        }

        public ModelDifferentialSave(string name, string sourcePath, string targetPath, string refSavePath) : base(name, sourcePath, targetPath)
        {
            saveRefPath = refSavePath;
        }

        /// <summary>
        /// methods to copy the files, trying to create the save and take every file form the source path.
        /// </summary>
        /// <param name="state">an object Log State to refer to</param>
        public override void Save(ref model.ModelLogState state)
        {
            try
            {
                //path to create a save folder
                string targetPathSave = String.Concat(targetPath, name);
                //if the save directory doesn't exit, create one
                if (!Directory.Exists(targetPathSave))
                {
                    Directory.CreateDirectory(targetPathSave);
                }
                string[] fileList = Directory.GetFiles(sourcePath);
                //search in the source path to compare with the saveref
                foreach (string f in fileList)
                {
                    filename = Path.GetFileName(f);
                    //If the file already exist in the saveref but has been modified, copy
                    if (File.Exists(String.Concat(saveRefPath, filename)))
                    {
                        if (File.GetLastWriteTime(String.Concat(saveRefPath, filename)) != File.GetLastWriteTime(String.Concat(sourcePath, filename)))
                        {
                            CopyAndWrite(ref state, name, sourcePath, filename, targetPathSave, String.Concat(targetPathSave, "/", filename));
                        }
                    }
                    //If the file does not exist in the saveref, copy
                    else
                    {
                        CopyAndWrite(ref state, name, sourcePath, filename, targetPathSave, String.Concat(targetPathSave, "/", filename));
                    }
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
