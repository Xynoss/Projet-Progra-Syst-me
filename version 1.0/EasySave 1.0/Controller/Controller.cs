using System;

namespace EasySave 1.0.Controller {
	public class Controller {
		private EasySave 1.0.Model.ModelSave[] saves;
		public EasySave 1.0.Model.ModelSave[] Saves {
			get {
				return saves;
			}
			set {
				saves = value;
			}
		}
		private EasySave 1.0.View.View view;
		public EasySave 1.0.View.View View {
			get {
				return view;
			}
			set {
				view = value;
			}
		}
		private EasySave 1.0.Model.LangConfig displayLanguage;

		public Controller(ref EasySave 1.0.Model.ModelSave[] saves, ref EasySave 1.0.View.View view, ref bool saveType) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void Start() {
			throw new System.NotImplementedException("Not implemented");
		}
		public void LogState(ref EasySave 1.0.Model.ModelSave[] save) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void LogLog(ref EasySave 1.0.Model.ModelSave[] save) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void DisplayLanguage() {
			throw new System.NotImplementedException("Not implemented");
		}

		private EasySave 1.0.View.View 1;
		private EasySave 1.0.Model.ModelSave 0_*;


	}

}
