using System.Collections.Generic;

namespace EasySave_1_0
{
    public class Program
    {
        public static void Main()
        {
            List<EasySave_1_0.Model.ModelSave> list_backup = new List<EasySave_1_0.Model.ModelSave>();
            View.View display = new View.View();
            Controller.Controller control = new Controller.Controller(list_backup, display, true);
        }
    }
}
