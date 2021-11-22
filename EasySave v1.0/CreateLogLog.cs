using System;

namespace LogClass {
	public class CreateLogLog : CreateLog  {
		private static CreateLogLog uniqueLog;

		private CreateLogLog(ref string pathLog) {
			throw new System.NotImplementedException("Not implemented");
		}
		public static CreateLogLog GetLog() {
			throw new System.NotImplementedException("Not implemented");
		}
		public override void WriteFile(ref string data) {
			throw new System.NotImplementedException("Not implemented");
		}

		private Model.ModelLogLog modelLogLog;

	}

}
