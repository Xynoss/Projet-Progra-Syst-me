using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Collections.Generic;

namespace EasySave_1_0.model {
	/// <summary>
	/// Abstract class for the save process.
	/// </summary>
	public abstract class ModelSave {
		protected string name;
		public string Name {
			get {
				return name;
			}
			set {
				name = value;
			}
		}
		
		protected string sourcePath;
		public string SourcePath {
			get {
				return sourcePath;
			}
			set {
				sourcePath = value;
			}
		}
		
		protected string targetPath;
		public string TargetPath {
			get {
				return targetPath;
			}
			set {
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

		/// <summary>
		/// Constructor for the save object.
		/// </summary>
		public ModelSave() { 
		}
		/// <summary>
		/// Second constructor for the save object
		/// </summary>
		/// <param name="name">name of the save</param>
		/// <param name="sourcePath">source path of the folder which will be save</param>
		/// <param name="targetPath">target path of the folder where it will be save</param>
		public ModelSave(string name, string sourcePath, string targetPath) {
			Name = name;
			TargetPath = targetPath;
			SourcePath = sourcePath;
		}
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
		public void CopyAndWrite(ref model.ModelLogState state, string Name, string sourcePath, string filename, string targetPath, string f)
        {
			DateTime start = DateTime.Now;
			state.State = "ACTIVE";
			File.Copy(Path.Combine(sourcePath, filename), Path.Combine(targetPath, filename), true);
			state.NbFilesLeft--;
			state.Prog();
			TimeSpan span = DateTime.Now - start;
			LogLog(Name, span, f, targetPath, sourcePath);
			LogState(Controller.Controller.States);
		}

		public abstract void CopyFolder(string sourcePath, string targetPath, ref ModelLogState modelLogState);
       
		public void DirectoryCreated(string dirPath)
        {
			//if the save directory doesn't exit, create one
			if (!Directory.Exists(dirPath))
			{
				Directory.CreateDirectory(dirPath);
			}
		}

		private static List<string> exToEnc = new List<string>();
		public static List<string> ExToEnc
		{
			get => exToEnc;
			set => exToEnc = value;
		}

		public abstract ModelLogState ToState();

	}

}
