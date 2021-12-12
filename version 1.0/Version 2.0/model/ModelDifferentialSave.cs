using System;
using System.Collections.Generic;
using System.IO;

namespace Version_2._0.model
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
        public override void Save(ref ModelLogState state)
        {
            try
            {
                CopyFolder(sourcePath, String.Concat(targetPath, name), ref state);
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }
            state.State = "END";
            LogState(view.iSave_comp.States);
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
        public override void LogState(List<ModelLogState> state)
        {
            Logger.GetInstance().WriteState(state);
        }

        public override void CopyFolder(string sourcePath, string targetPath, ref ModelLogState modelLogState)
        {
            DirectoryCreated(targetPath);
            bool pathSame = String.Equals(
                        Path.GetFullPath(sourcePath).TrimEnd('\\'),
                        Path.GetFullPath(this.sourcePath).TrimEnd('\\'),
                        StringComparison.InvariantCultureIgnoreCase);
            string subDir = "";
            if (!pathSame)
            {
                string dirSrc = new DirectoryInfo(this.sourcePath).Name;
                int index = sourcePath.LastIndexOf(dirSrc, StringComparison.InvariantCultureIgnoreCase) + dirSrc.Length + 1;
                subDir = String.Concat(sourcePath.Substring(index), "/");
            }
            foreach (string f in Directory.EnumerateFiles(sourcePath))
            {
                filename = Path.GetFileName(f);
                string saveRefToCheck = String.Concat(saveRefPath, subDir, filename);
                //If the file already exist in the saveref but has been modified, copy
                if (File.Exists(saveRefToCheck))
                {
                    if (File.GetLastWriteTime(f) != File.GetLastWriteTime(saveRefToCheck))
                    {
                        CopyAndWrite(ref modelLogState, name, sourcePath, filename, targetPath, String.Concat(targetPath, "/", filename));
                    }
                }
                //If the file does not exist in the saveref, copy
                else
                {
                    CopyAndWrite(ref modelLogState, name, sourcePath, filename, targetPath, String.Concat(targetPath, "/", filename));
                }
            }
            foreach (string d in Directory.EnumerateDirectories(sourcePath))
            {
                string foldername = Path.GetFileName(d);
                string saveRefToCheck = String.Concat(saveRefPath, subDir, foldername);
                if (Directory.Exists(saveRefToCheck))
                {
                    if (Directory.GetLastWriteTime(d) >= File.GetLastWriteTime(saveRefToCheck))
                    {
                        CopyFolder(d, String.Concat(targetPath, "/", new DirectoryInfo(d).Name), ref modelLogState);
                    }
                }
                else
                {
                    CopyFolder(d, String.Concat(targetPath, "/", new DirectoryInfo(d).Name), ref modelLogState);
                }
            }

        }

    }
}
