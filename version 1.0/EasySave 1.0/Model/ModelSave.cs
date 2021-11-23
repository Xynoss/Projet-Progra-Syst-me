using System;

/// <summary>
/// class for a model of the save to create a save with a name, source path, and a target path
/// </summary>
/// <autor>
/// THOMAS Maxime
/// </autor>
namespace Model {
	public abstract class ModelSave {

		/// <summary>
		/// name of the save definition
		/// </summary>
		private string name;
		public string Name {
			get {
				return name;
			}
			set {
				name = value;
			}
		}

		/// <summary>
		/// source path definition
		/// </summary>
		private string sourcePath;
		public string SourcePath {
			get {
				return sourcePath;
			}
			set {
				sourcePath = value;
			}
		}

		/// <summary>
		/// target path definition
		/// </summary>
		private string targetPath;
		public string TargetPath {
			get {
				return targetPath;
			}
			set {
				targetPath = value;
			}
		}

		/// <summary>
		/// creator of the class ModelSave which save the target and source path plus the name of the save
		/// </summary>
		/// <param name="name">name of the save</param>
		/// <param name="sourcePath">source path of the file</param>
		/// <param name="targetPath">target path of the save</param>
		public ModelSave(ref string name, ref string sourcePath, ref string targetPath) {
			this.TargetPath = targetPath;
			this.SourcePath = sourcePath;
			this.Name = name;
		}

		/// <summary>
		/// 
		/// </summary>
		public abstract void Save();

		private MapperClass.MapperLog mapperLog;
		private MapperClass.MapperState mapperState;
		private Controller.ControllerSave controllerSave;

	}

}
