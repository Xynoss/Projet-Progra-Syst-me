using System;

namespace LogClass {
	public class CreateLogState : CreateLog  {
		private static CreateLogState uniqueState;

		private CreateLogState(ref string pathLog) {
			throw new System.NotImplementedException("Not implemented");
		}
		public static CreateLogState GetState() {
			throw new System.NotImplementedException("Not implemented");
		}
		public override void WriteFile(ref string data) {
			throw new System.NotImplementedException("Not implemented");
		}

		private Model.ModelLogState modelLogState;

	}

}
