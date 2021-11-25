using System;
using System.Collections.Generic;
using EasySave_1._0.controller;
namespace EasySave_1_0
{
    public class Program {
		public static void Main() {
			Controller controller = new Controller(new List<model.ModelSave>(), new View.View());
			controller.select_language();
		}

		/*private Controller obj_controller;*/

	}

}
