using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Version_2._0.model
{
    public abstract class ModelSave
    {
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

		public ModelSave()
		{
		}

		public ModelSave(string name, string sourcePath, string targetPath)
		{
			Name = name;
			TargetPath = targetPath;
			SourcePath = sourcePath;
		}

		public abstract void Save(ref model.ModelLogState state);
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
			TimeSpan span = DateTime.Now - start;
			LogLog(Name, span, f, targetPath, sourcePath);
			LogState(view.iSave_comp.States);
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
	}
}
