using System;

namespace Model {
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

		public void ModelSave(ref string name, ref string sourcePath, ref string targetPath) {
			throw new System.NotImplementedException("Not implemented");
		}
		public abstract void Save();

		private MapperClass.MapperLog mapperLog;
		private MapperClass.MapperState mapperState;
		private Controller.ControllerSave controllerSave;

	}

}
