using System;

namespace Model {
	public class ModelLogLog : ModelLog  {
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

		private MapperClass.MapperLog mapperLog;
		private LogClass.CreateLogLog createLogLog;

	}

}
