using System;
using System.Globalization;
using System.Resources;

namespace EasySave_1._0.controller{
    public class Controller
    {
        private ResourceManager res_man;
        private CultureInfo Culture;
        private EasySave_1_0.Model.ModelSave[] saves;
        public EasySave_1_0.Model.ModelSave[] Saves
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

        public Controller(ref EasySave_1_0.Model.ModelSave[] saves, ref EasySave_1_0.View.View view, ref bool saveType)
        {
            Culture = CultureInfo.CreateSpecificCulture("en");
            res_man = new ResourceManager("EasySave_1_0.Properties.Res", typeof(Controller).Assembly);
        }
        public void select_language()
        {
            view.Output(res_man.GetString("greeting", Culture));
        }
        public void Start()
        {
            throw new NotImplementedException("Not implemented");
        }
        public void LogState(ref EasySave_1_0.Model.ModelSave[] save)
        {
            throw new NotImplementedException("Not implemented");
        }
        public void LogLog(ref EasySave_1_0.Model.ModelSave[] save)
        {
            throw new NotImplementedException("Not implemented");
        }
        /*public void DisplayLanguage(EasySave_1_0.Model.LangConfig) {
			throw new System.NotImplementedException("Not implemented");
		}*/



    }

}
