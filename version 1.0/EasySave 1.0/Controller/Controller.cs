using System.Collections.Generic;
using System.Globalization;
using System.Resources;


namespace EasySave_1_0.Controller
{
    public class Controller
    {

        string save_name = "";

        private ResourceManager res_man;
        private CultureInfo culture;
        private static List<EasySave_1_0.model.ModelLogState> states = new List<model.ModelLogState>();
        public static List<EasySave_1_0.model.ModelLogState> States
        {
            get { return states; }
            set { states = value; }
        }

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

        /// <summary>
        /// contructor of the controller.
        /// </summary>
        /// <param name="saves">list of saves</param>
        /// <param name="view">call of the view used for the IHM</param>
        /// <param name="saveType">Select the save type</param>
        public Controller(List<EasySave_1_0.model.ModelSave> saves, EasySave_1_0.View.View view, bool saveType)
        {
            this.view = view;
            this.saves = saves;
            culture = CultureInfo.CreateSpecificCulture("en");
            res_man = new ResourceManager("EasySave_1_0.Properties.Res", typeof(Controller).Assembly);
            Start();
        }

        /// <summary>
        /// the starting method of the application
        /// </summary>
        public void Start()
        {
            string Input_choise = "";
            //int save_selected = 0;
            this.view.Output(this.res_man.GetString("greeting", this.culture));
            this.view.Output(this.res_man.GetString("language_choose", this.culture));
            this.view.Output(this.res_man.GetString("language_en", this.culture));
            this.view.Output(this.res_man.GetString("language_fr", this.culture));
            Input_choise = this.view.Input();

            switch (Input_choise)
            {
                case "1"://choose the english language
                    culture = CultureInfo.CreateSpecificCulture("en");
                    this.view.Output(this.res_man.GetString("check_language", this.culture));
                    break;
                case "2"://choose the french language 
                    culture = CultureInfo.CreateSpecificCulture("fr");
                    this.view.Output(this.res_man.GetString("check_language", this.culture));
                    break;
            }
            while (Input_choise != "5")//5 is to exit the app
            {
                this.view.Output(this.res_man.GetString("choose_action", this.culture));
                this.view.Output(this.res_man.GetString("list_create_save", this.culture));
                this.view.Output(this.res_man.GetString("list_delete_save", this.culture));
                this.view.Output(this.res_man.GetString("list_run_all", this.culture));
                this.view.Output("4 : list the save"/*this.res_man.GetString("list_run_one", this.culture)*/);
                this.view.Output(this.res_man.GetString("list_exit", this.culture));
                Input_choise = this.view.Input();




                switch (Input_choise)
                {
                    case "1": //create a backup total
                        this.view.Output(this.res_man.GetString("save_complete_chosen", this.culture));
                        createTotal();
                        break;

                    case "2": //create a differential backup
                        this.view.Output(this.res_man.GetString("save_differential_chosen", this.culture));
                        createDifferential();
                        //delete a backup from the list
                        //    this.view.Output(this.res_man.GetString("choose_save", this.culture));
                        //    Input_choise = this.view.Input();

                        //    try
                        //    {
                        //        int i = 0;
                        //        while (Input_choise != save_name)
                        //        {
                        //            save_name = saves[i].Name;
                        //            i++;
                        //        }
                        //        save_selected = i;
                        //    }
                        //    catch
                        //    {

                        //    }

                        //    this.view.Output(string.Format(this.res_man.GetString("confirm_delete", this.culture), save_name));
                        //    Input_choise = this.view.Input();
                        //    if (Input_choise == "y")
                        //    {
                        //        Saves.Remove(saves[save_selected]);
                        //        this.view.Output(string.Format(this.res_man.GetString("delete_end", this.culture), save_name));
                        //        save_name = "";
                        //    }
                        //    else
                        //    {
                        //        this.view.Output(this.res_man.GetString("cancel_delete", this.culture));
                        //    }

                        break;

                    case "3": //it's will be the full job of save 
                        this.view.Output("not implemented yet");
                        break;

                    case "4": //list of the backup
                        foreach (model.ModelTotalSave Asave in saves)
                        {
                            int i = 1;
                            this.view.Output(string.Concat(i, " : ", Asave.Name));
                            i++;
                        }

                        break;
                }
            }

            this.view.Output(this.res_man.GetString("end", this.culture));

        }

        private void createTotal()
        {
            if (saves.Count < 6)
            {
                this.view.Output(this.res_man.GetString("ask_name_save", this.culture));
                save_name = this.view.Input();
                this.view.Output(this.res_man.GetString("ask_source_path", this.culture));
                string save_sourcepath = this.view.Input();
                this.view.Output(this.res_man.GetString("ask_target_path", this.culture));
                string save_targetpath = this.view.Input();
                model.ModelSave currentSave = new model.ModelTotalSave(save_name, save_sourcepath, save_targetpath);
                saves.Add(currentSave);
                model.ModelLogState statefile = new model.ModelLogState(save_name, save_sourcepath, save_targetpath);
                this.view.Output(string.Format(this.res_man.GetString("save_loading", this.culture), save_name));
                states.Add(statefile);
                currentSave.Save(ref statefile);
            }
            else
            {
                this.view.Output(this.res_man.GetString("ask_target_save", this.culture));
            }
            this.view.Output(string.Format(this.res_man.GetString("save_created", this.culture), save_name));
        }

        private void createDifferential()
        {
            if (saves.Count < 6)
            {
                this.view.Output(this.res_man.GetString("ask_name_save", this.culture));
                save_name = this.view.Input();
                this.view.Output(this.res_man.GetString("choose_save_ref", this.culture));
                string save_ref = this.view.Input();
                string save_sourcepath = "";
                for (int i = 0; i < saves.Count; i++)
                {
                    if (save_ref == saves[i].Name)
                    {
                        save_sourcepath = saves[i].SourcePath;
                        this.view.Output(this.res_man.GetString("ask_target_path", this.culture));
                        string save_targetpath = this.view.Input();
                        saves.Add(new model.ModelDifferentialSave(save_name, save_sourcepath, save_targetpath, save_ref));
                        model.ModelLogState statefile = new model.ModelLogState(save_name, save_sourcepath, save_targetpath);
                        this.view.Output(string.Format(this.res_man.GetString("save_loading", this.culture), save_name));
                        states.Add(statefile);
                        saves[i].Save(ref statefile);
                    }
                    else
                    {
                        this.view.Output("erreur sauvegarde d'origin non trouvé");
                    }

                }

            }
            else
            {
                this.view.Output(this.res_man.GetString("ask_target_save", this.culture));
            }
            this.view.Output(string.Format(this.res_man.GetString("save_created", this.culture), save_name));

        }


    }

}
