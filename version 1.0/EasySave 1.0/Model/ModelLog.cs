using System;

namespace Model {
	public abstract class ModelLog {
		private string name;
		public string Name {
			get {
				return name;
			}
			set {
				name = value;
			}
		}
		private string fileSource;
		public string FileSource {
			get {
				return fileSource;
			}
			set {
				fileSource = value;
			}
		}
		private string fileTarget;
		public string FileTarget {
			get {
				return fileTarget;
			}
			set {
				fileTarget = value;
			}
		}
		private DateTime timestamp;
		public DateTime Timestamp {
			get {
				return timestamp;
			}
			set {
				timestamp = value;
			}
		}
	protected string PathLog;
	protected string SourcePath;
	protected string TargetPath;
	protected string message = " ";

<<<<<<< Updated upstream
=======
	public abstract void CreateLogFile();
		public abstract void WriteLog();
		public abstract void Save();

>>>>>>> Stashed changes
	}

}
