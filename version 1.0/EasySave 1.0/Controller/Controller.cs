using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;

namespace EasySave_1._0.controller{
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
        //private EasySave_1_0.Model.LangConfig displayLanguage;

        public Controller(List<EasySave_1_0.model.ModelSave> saves, EasySave_1_0.View.View view)
        {
            this.view = view;
            culture = CultureInfo.CreateSpecificCulture("en");
            res_man = new ResourceManager("EasySave_1_0.Properties.Res", typeof(Controller).Assembly);
        }
        public void select_language()
        {
            view.Output(res_man.GetString("greeting", culture));
        }
        public void Start()
        {
            throw new NotImplementedException("Not implemented");
        }
        /*public void LogState(ref EasySave_1_0.Model.ModelSave[] save)
        {
            throw new NotImplementedException("Not implemented");
        }
        public void LogLog(ref EasySave_1_0.Model.ModelSave[] save)
        {
            throw new NotImplementedException("Not implemented");
        }*/
        /*public void DisplayLanguage(EasySave_1_0.Model.LangConfig) {
			throw new System.NotImplementedException("Not implemented");
		}*/



    }

}
