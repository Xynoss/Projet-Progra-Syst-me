using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;


namespace EasySave_1_0.Controller
{
    public class Controller
    {
        private ResourceManager res_man;
        private CultureInfo culture;

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
        private EasySave_1_0.Model.LangConfig displayLanguage;

        public Controller(List<EasySave_1_0.model.ModelSave> saves, EasySave_1_0.View.View view, bool saveType)
        {
            this.view = View;
            this.saves = saves;
            culture = CultureInfo.CreateSpecificCulture("en");
            res_man = new ResourceManager("EasySave_1_0.Properties.Res", typeof(Controller).Assembly);
            Start();
        }
        public void Start()
        {


            view.Output("que faire :");
            string Input_choise = view.Input();
            /*switch (Input_choise != null)
            {
                case false:
                    Input_choise = 
            }*/

            view.Output("créer une sauvegarde ? y => YES ");
            Input_choise = view.Input();
            if (Input_choise == "y" && saves.Count < 6)
            {
                view.Output("le nom :");
                string save_name = view.Input();
                view.Output("la source :");
                string save_sourcepath = view.Input();
                view.Output("la cible :");
                string save_targetpath = view.Input();
                saves.Add(new model.ModelTotalSave(save_name, save_sourcepath, save_targetpath));
            }
            else
            {
                view.Output("tu ne peux pas créer !");
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
        public void select_language()
        {
            view.Output(res_man.GetString("greeting", culture));
        }


    }

}
