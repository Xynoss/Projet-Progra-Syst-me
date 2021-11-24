using System;
using System.IO;
using System.Diagnostics;
using System.Reflection;

namespace EasySave_1_0.model {
	public class ModelSave {
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
		protected string pathLog;
		public string PathLog {
			get {
				return pathLog;
			}
			set {
				pathLog = value;
			}
		}
		public ModelSave() { 
		}
		public ModelSave(string name, string sourcePath, string targetPath) {
			Name = name;
			TargetPath = targetPath;
			SourcePath = sourcePath;

		}

		//public abstract void Save();


	}

}
