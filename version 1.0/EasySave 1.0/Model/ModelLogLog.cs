using System;

namespace EasySave 1.0.Model {
	public class ModelLogLog : ModelLog  {
		private static EasySave_1.0.Model.ModelLogLog instance;
		private int fileSize;
		public int FileSize {
			get {
				return fileSize;
			}
			set {
				fileSize = value;
			}
		}
		private int timeTransfert;
		public int TimeTransfert {
			get {
				return timeTransfert;
			}
			set {
				timeTransfert = value;
			}
		}

		public override void CreateLogFile() {
			throw new System.NotImplementedException("Not implemented");
		}
		public override void WriteLog() {
			throw new System.NotImplementedException("Not implemented");
		}
		private ModelLogLog() {
			throw new System.NotImplementedException("Not implemented");
		}
		public static EasySave_1.0.Model.ModelLogLog GetInstance() {
			return this.instance;
		}

		private Calcul_Check 0_*;

	}

}
