using System;

namespace Controller {
	public class ControllerLog {
		private MapperClass.MapperState stateMap;
		public MapperClass.MapperState StateMap {
			get {
				return stateMap;
			}
			set {
				stateMap = value;
			}
		}
		private MapperClass.MapperLog logMap;
		public MapperClass.MapperLog LogMap {
			get {
				return logMap;
			}
			set {
				logMap = value;
			}
		}
		private LogClass.CreateLog logControl;
		public LogClass.CreateLog LogControl {
			get {
				return logControl;
			}
			set {
				logControl = value;
			}
		}
		private LogClass.CreateLog stateControl;
		public LogClass.CreateLog StateControl {
			get {
				return stateControl;
			}
			set {
				stateControl = value;
			}
		}

		public ControllerLog(ref MapperClass.MapperLog logMap, ref MapperClass.MapperState stateMap) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void LogState(ref Model.ModelSave[] save) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void LogLog(ref Model.ModelSave[] save) {
			throw new System.NotImplementedException("Not implemented");
		}

		private LogClass.CreateLog createLog;
		private MapperClass.MapperState mapperState;
		private MapperClass.MapperLog mapperLog;

		private ControllerSave controllerSave;

	}

}
