using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace EasySave_1_0.model
{
    
    /// <summary>
    /// Abstract class for the save process.
    /// </summary>
    public abstract class ModelSave
    {
        #region attribut et setter getter
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

        protected string sourcePath;
        public string SourcePath
        {
            get
            {
                return sourcePath;
            }
            set
            {
                sourcePath = value;
            }
        }

        protected string targetPath;
        public string TargetPath
        {
            get
            {
                return targetPath;
            }
            set
            {
                targetPath = value;
            }
        }

        protected string filename;
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

        public string Details
        {
            get
            {
                return String.Format("back up {0} from {1} to {2} folder", Name, SourcePath, targetPath);
            }
        }
        
        private static List<string> exToEnc = new List<string>();
        public static List<string> ExToEnc
        {
            get => exToEnc;
            set => exToEnc = value;
        }
        #endregion
        #region constructeur
        /// <summary>
        /// Constructor for the save object.
        /// </summary>
        public ModelSave()
        {
        }
        /// <summary>
        /// Second constructor for the save object
        /// </summary>
        /// <param name="name">name of the save</param>
        /// <param name="sourcePath">source path of the folder which will be save</param>
        /// <param name="targetPath">target path of the folder where it will be save</param>
        public ModelSave(string name, string sourcePath, string targetPath)
        {
            Name = name;
            TargetPath = targetPath;
            SourcePath = sourcePath;
        }
        #endregion
        #region Méthodes
        /// <summary>
        /// Abstract method to save folders and files
        /// </summary>
        public abstract void Save(ref model.ModelLogState state, ref List<model.ModelLogState> l_state);
        /// <summary>
        /// Abstract method to initialize the writing of the state's file
        /// </summary>
        public abstract void LogState(List<model.ModelLogState> state);
        /// <summary>
        /// Abstract method to initialize the writing of the log's file
        /// </summary>
        /// <param name="str_in">file concerned at the moment of the process.</param>
        public abstract void LogLog(string name, TimeSpan span, string filename, string targetPath, string sourcePath);
        
        public void CopyAndWrite(ref model.ModelLogState state, string Name, string sourcePath, string filename, string targetPath, string f, ref List<ModelLogState> states)
        {
            DateTime start = DateTime.Now;
            state.State = "ACTIVE";
            string ext = Path.GetExtension($"{sourcePath}\\{filename}");
            if (ExToEnc.Contains(ext))
            {
                Process process = new Process();
                string d = Directory.GetCurrentDirectory();
                process.StartInfo.FileName = "CryptoSoft/CryptoSoft.exe";
                process.StartInfo.CreateNoWindow = true;
                string file = Path.GetFullPath(String.Concat(sourcePath, "/", filename));
                string target = Path.GetFullPath(targetPath);
                process.StartInfo.Arguments = $"/e \"{file}\" \"{target}\\{Path.GetFileName(filename)}\" 1234567891234567";
                process.Start();
                process.WaitForExit();
                File.SetLastWriteTime($"{target}\\{Path.GetFileName(file)}", File.GetLastWriteTime(file));
            }
            else
            {
                File.Copy(Path.Combine(sourcePath, filename), Path.Combine(targetPath, filename), true);
            }
            state.NbFilesLeft--;
            state.Prog();
            TimeSpan span = DateTime.Now - start;
            LogLog(Name, span, f, targetPath, sourcePath);
            LogState(states);
        }

        public abstract void CopyFolder(string sourcePath, string targetPath, ref ModelLogState modelLogState, ref List<ModelLogState> states);
        /// <summary>
        /// Method to create directory when it does not exist
        /// </summary>
        /// <param name="dirPath">path of the directory</param>
        public void DirectoryCreated(string dirPath)
        {
            //if the save directory doesn't exit, create one
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
        }
        /// <summary>
        /// a method to transform a Save to a State Model
        /// </summary>
        /// <returns>the state created</returns>
        public abstract ModelLogState ToState();
        /// <summary>
        /// initialize the State
        /// </summary>
        /// <param name="state">State to initialize</param>
        protected void InitState(ref ModelLogState state)
        {
            state.Progression = 0;
            state.NbFilesLeft = new Calcul_Check().NbFiles(sourcePath);
            state.TotalFileToCopy = state.NbFilesLeft;
            state.TotalFileSize = new Calcul_Check().FileSize(sourcePath);
        }
        #endregion
    }

}
