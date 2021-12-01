using System;

namespace Controller {
	public class ControllerSave {
		private ControllerLog logControl;
		public ControllerLog LogControl {
			get {
				return logControl;
			}
			set {
				logControl = value;
			}
		}
		private Model.ModelSave[] saves;
		public Model.ModelSave[] Saves {
			get {
				return saves;
			}
			set {
				saves = value;
			}
		}
		private View.View view;
		public View.View View {
			get {
				return view;
			}
			set {
				view = value;
			}
		}

		public ControllerSave(ref Model.ModelSave[] saves, ref View.View view, ref bool saveType) {
			throw new System.NotImplementedException("Not implemented");
		}
		public void Start() {
			throw new System.NotImplementedException("Not implemented");
		}

		private ControllerLog controllerLog;
		private Model.ModelSave modelSave;

		private Program program;

	}

}
