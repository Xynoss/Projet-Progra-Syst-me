using System;

namespace LogClass {
	public abstract class CreateLog {
		private string pathLog;
		public string PathLog {
			get {
				return pathLog;
			}
			set {
				pathLog = value;
			}
		}

		public abstract void WriteFile(ref string data);

		private Controller.ControllerLog controllerLog;

	}

}
