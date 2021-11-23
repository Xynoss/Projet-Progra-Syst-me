using System;

namespace Model {
	public class ModelLogState : ModelLog  {
		private bool state;
		private int totalFileToCopy;
		public int TotalFileToCopy {
			get {
				return totalFileToCopy;
			}
			set {
				totalFileToCopy = value;
			}
		}
		private int totalFileSize;
		public int TotalFileSize {
			get {
				return totalFileSize;
			}
			set {
				totalFileSize = value;
			}
		}
		private int progression;
		public int Progression {
			get {
				return progression;
			}
			set {
				progression = value;
			}
		}
		private int nbFilesLeft;
		public int NbFilesLeft {
			get {
				return nbFilesLeft;
			}
			set {
				nbFilesLeft = value;
			}
		}

		private MapperClass.MapperState mapperState;
		private LogClass.CreateLogState createLogState;

	}

}
