using System.Collections.Generic;

namespace EasySave_1_0.Controller
{
    public class Controller
    {
        private List<EasySave_1_0.Model.ModelSave> saves;
        public List<EasySave_1_0.Model.ModelSave> Saves
        {
            get
            {
                return saves;
            }
            set
            {
                saves = value;
            }
        }
        private EasySave_1_0.View.View view;
        public EasySave_1_0.View.View View
        {
            get
            {
                return view;
            }
            set
            {
                view = value;
            }
        }
        private EasySave_1_0.Model.LangConfig displayLanguage;

        public Controller(List<EasySave_1_0.Model.ModelSave> saves, EasySave_1_0.View.View view, bool saveType)
        {

        }
        public void Start()
        {
            List<EasySave_1_0.Model.ModelSave> list_backup = new List<EasySave_1_0.Model.ModelSave>();
            View.View display = new View.View();
            Controller control = new Controller(list_backup, display, true);

            display.Output("que faire :");
            string Input_choise = display.Input();
            /*switch (Input_choise != null)
            {
                case false:
                    Input_choise = 
            }*/

            display.Output("créer une sauvegarde ? y => YES ");
            Input_choise = display.Input();
            if (Input_choise == "y" && list_backup.Count < 6)
            {
                display.Output("le nom :");
                string save_name = display.Input();
                display.Output("la source :");
                string save_sourcepath = display.Input();
                display.Output("la cible :");
                string save_targetpath = display.Input();
                list_backup.Add(new Model.ModelTotalSave(save_name, save_sourcepath, save_targetpath));
            }
            else
            {
                display.Output("tu ne peux pas créer !");
            }



        }
        public void LogState(ref EasySave_1_0.Model.ModelSave[] save)
        {
            throw new System.NotImplementedException("Not implemented");
        }
        public void LogLog(ref EasySave_1_0.Model.ModelSave[] save)
        {
            throw new System.NotImplementedException("Not implemented");
        }
        public void DisplayLanguage()
        {
            throw new System.NotImplementedException("Not implemented");
        }


    }

}
