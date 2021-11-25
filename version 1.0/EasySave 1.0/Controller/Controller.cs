using System.Collections.Generic;
using System.Globalization;
using System.Resources;


namespace EasySave_1_0.Controller
{
    public class Controller
    {
        private ResourceManager res_man;
        private CultureInfo culture;
        static private List<EasySave_1_0.model.ModelLogState> states = new List<model.ModelLogState>();
        private List<EasySave_1_0.model.ModelSave> saves;
        public List<EasySave_1_0.model.ModelSave> Saves
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

        public Controller(List<EasySave_1_0.model.ModelSave> saves, EasySave_1_0.View.View view, bool saveType)
        {
            this.view = view;
            this.saves = saves;
            culture = CultureInfo.CreateSpecificCulture("en");
            res_man = new ResourceManager("EasySave_1_0.Properties.Res", typeof(Controller).Assembly);
            Start();
        }
        public void Start()
        {


            this.view.Output("que faire :");
            string Input_choise = this.view.Input();
            /*switch (Input_choise != null)
            {
                case false:
                    Input_choise = 
            }*/

            this.view.Output("créer une sauvegarde ? y => YES ");
            Input_choise = this.view.Input();
            if (Input_choise == "y" && saves.Count < 6)
            {
                this.view.Output("le nom :");
                string save_name = this.view.Input();
                this.view.Output("la source :");
                string save_sourcepath = this.view.Input();
                this.view.Output("la cible :");
                string save_targetpath = this.view.Input();
                saves.Add(new model.ModelTotalSave(save_name, save_sourcepath, save_targetpath));
                states.Add(new model.ModelLogState(save_name, save_sourcepath,save_targetpath));
                saves[0].Save();
            }
            else
            {
                this.view.Output("tu ne peux pas créer !");
            }



        }
        public void LogState(ref EasySave_1_0.model.ModelSave[] save)
        {
            throw new System.NotImplementedException("Not implemented");
        }
        public void LogLog(ref EasySave_1_0.model.ModelSave[] save)
        {
            throw new System.NotImplementedException("Not implemented");
        }
        /// <summary>
        /// Method to select the language at the start of the application
        /// </summary>
        public void select_language()
        {
            view.Output(res_man.GetString("greeting", culture));
        }


    }

}
