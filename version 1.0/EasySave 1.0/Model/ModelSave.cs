using System;

namespace EasySave 1.0.Model {
	public abstract class ModelSave {
		private string name;
		public string Name {
			get {
				return name;
			}
			set {
				name = value;
			}
		}
		private string sourcePath;
		public string SourcePath {
			get {
				return sourcePath;
			}
			set {
				sourcePath = value;
			}
		}
		private string targetPath;
		public string TargetPath {
			get {
				return targetPath;
			}
			set {
				targetPath = value;
			}
		}
		private string pathLog;
		public string PathLog {
			get {
				return pathLog;
			}
			set {
				pathLog = value;
			}
		}

		public void ModelSave(ref string name, ref string sourcePath, ref string targetPath) {
			throw new System.NotImplementedException("Not implemented");
		}
		public abstract void Save();

		private EasySave 1.0.Controller.Controller 1;

	}

}
