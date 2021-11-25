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
            string Input_choise = "";
            string save_name = "";
            int save_selected = 0;
            this.view.Output(this.res_man.GetString("greeting", this.culture));
            this.view.Output(this.res_man.GetString("language_choose", this.culture));
            this.view.Output(this.res_man.GetString("language_en", this.culture));
            this.view.Output(this.res_man.GetString("language_fr", this.culture));
            Input_choise = this.view.Input();

            switch (Input_choise)
            {
                case "1":
                    culture = CultureInfo.CreateSpecificCulture("en");
                    this.view.Output(this.res_man.GetString("check_language", this.culture));
                    break;
                case "2":
                    culture = CultureInfo.CreateSpecificCulture("fr");
                    this.view.Output(this.res_man.GetString("check_language", this.culture));
                    break;
            }

            this.view.Output(this.res_man.GetString("choose_action", this.culture));
            this.view.Output(this.res_man.GetString("list_create_save", this.culture));
            this.view.Output(this.res_man.GetString("list_delete_save", this.culture));
            this.view.Output(this.res_man.GetString("list_run_all", this.culture));
            this.view.Output(this.res_man.GetString("list_run_one", this.culture));
            this.view.Output(this.res_man.GetString("list_exit", this.culture));
            Input_choise = this.view.Input();




            switch (Input_choise)
            {
                case "1": //create back_up
                    this.view.Output(this.res_man.GetString("save_create_chosen", this.culture));
                    Input_choise = this.view.Input();
                    if (Input_choise == "y" && saves.Count < 6)
                    {
                        this.view.Output(this.res_man.GetString("ask_name_save", this.culture));
                        save_name = this.view.Input();
                        this.view.Output(this.res_man.GetString("ask_source_path", this.culture));
                        string save_sourcepath = this.view.Input();
                        this.view.Output(this.res_man.GetString("ask_target_path", this.culture));
                        string save_targetpath = this.view.Input();
                        saves.Add(new model.ModelTotalSave(save_name, save_sourcepath, save_targetpath));
                        saves[0].Save();
                    }
                    else
                    {
                        this.view.Output(this.res_man.GetString("ask_target_save", this.culture));
                    }
                    break;

                case "2": //delete backup
                    this.view.Output(this.res_man.GetString("choose_save", this.culture));
                    Input_choise = this.view.Input();

                    try
                    {
                        int i = 0;
                        while (Input_choise != save_name)
                        {
                            save_name = saves[i].Name;
                            i++;
                        }
                        save_selected = i;
                    }
                    catch
                    {

                    }

                    this.view.Output(string.Format(this.res_man.GetString("confirm_delete", this.culture), save_name));
                    Input_choise = this.view.Input();
                    if (Input_choise == "y")
                    {
                        Saves.Remove(saves[save_selected]);
                        this.view.Output(string.Format(this.res_man.GetString("delete_end", this.culture), save_name));
                        save_name = "";
                    }
                    else
                    {
                        this.view.Output(this.res_man.GetString("cancel_delete", this.culture));
                    }

                    break;

                case "3":

                    break;

                case "4":

                    break;
            }
            this.view.Output(this.res_man.GetString("end", this.culture));

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
