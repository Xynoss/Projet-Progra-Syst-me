using System;

namespace EasySave_1_0.Controller {
	public class Controller {
		private EasySave_1_0.Model.ModelSave[] saves;
		public EasySave_1_0.Model.ModelSave[] Saves {
			get {
				return saves;
			}
			set {
				saves = value;
			}
		}
		private EasySave_1_0.View.View view;
		public EasySave_1_0.View.View View {
			get {
				return view;
			}
			set {
				view = value;
			}
		}
		private EasySave_1_0.Model.LangConfig displayLanguage;

		public Controller(ref EasySave_1_0.Model.ModelSave[] saves, ref EasySave_1_0.View.View view, ref bool saveType) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void Start() {
			throw new System.NotImplementedException("Not implemented");
		}
		public void LogState(ref EasySave_1_0.Model.ModelSave[] save) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void LogLog(ref EasySave_1_0.Model.ModelSave[] save) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void DisplayLanguage(EasySave_1_0.Model.LangConfig) {
			throw new System.NotImplementedException("Not implemented");
		}



	}

}
