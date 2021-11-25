using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace EasySave_1_0.Model {
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

		public ModelSave(string name, string sourcePath, string targetPath) {
			Name = name;
			TargetPath = targetPath;
			SourcePath = sourcePath;
		}

		public abstract void Save();


	}

}
