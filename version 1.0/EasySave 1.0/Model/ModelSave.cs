using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;

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
		public abstract void Save(ref model.ModelLogState state);
		/// <summary>
		/// Abstract method to initialize the writing of the state's file
		/// </summary>
		public abstract void LogState(string name, string fileSource, string fileTarget, string state);
		/// <summary>
		/// Abstract method to initialize the writing of the log's file
		/// </summary>
		/// <param name="str_in">file concerned at the moment of the process.</param>
		public abstract void LogLog(string name, TimeSpan span, string filename, string targetPath, string sourcePath);

	}

}
