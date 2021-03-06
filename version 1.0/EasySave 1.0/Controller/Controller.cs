using EasySave_1_0.model;
using System;
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
                this.view.Output(this.res_man.GetString("list_complete_save", this.culture));
                this.view.Output(this.res_man.GetString("list_diff_save", this.culture));
                this.view.Output(this.res_man.GetString("list_run_all", this.culture));
                this.view.Output(this.res_man.GetString("list_run_one", this.culture));
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
                        break;

                    case "3": //run all save
                        this.view.Output(this.res_man.GetString("run_all_save", this.culture));
                        for (byte i = 0; i < states.Count; i++)
                        {
                            ModelLogState current_states = states[i];
                            this.view.Output(string.Format(this.res_man.GetString("save_loading", this.culture), states[i]));
                            this.saves[i].Save(ref current_states);
                            this.view.Output(string.Format(this.res_man.GetString("save_created", this.culture), states[i]));
                        }
                        break;

                    case "4": //run one save
                        this.view.Output(this.res_man.GetString("run_onesave", this.culture));
                        this.view.Output(this.res_man.GetString("choose_save", this.culture));
                        int nbsave = 0;
                        foreach(ModelSave save in this.saves)
                        {
                            this.view.Output(String.Format("{0} : {1}", nbsave, save.Name));
                            nbsave++;
                        }
                        int selected_save = int.Parse(this.view.Input());
                        ModelLogState correct_state = states[selected_save];
                        this.view.Output(string.Format(this.res_man.GetString("save_loading", this.culture), selected_save));
                        Saves[selected_save].Save(ref correct_state);
                        this.view.Output(string.Format(this.res_man.GetString("save_created", this.culture), selected_save));
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
                ModelSave currentSave = new ModelTotalSave(save_name, save_sourcepath, save_targetpath);
                saves.Add(currentSave);
                ModelLogState statefile = new ModelLogState(save_name, save_sourcepath, save_targetpath);
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
                        ModelSave modelSave = new model.ModelDifferentialSave(save_name, save_sourcepath, save_targetpath, String.Concat(saves[i].TargetPath, save_ref, "/"));
                        saves.Add(modelSave);
                        model.ModelLogState statefile = new model.ModelLogState(save_name, save_sourcepath, save_targetpath);
                        this.view.Output(string.Format(this.res_man.GetString("save_loading", this.culture), save_name));
                        states.Add(statefile);
                        modelSave.Save(ref statefile);
                        this.view.Output(string.Format(this.res_man.GetString("save_created", this.culture), save_name));
                    }
                    else
                    {
                        this.view.Output(this.res_man.GetString("notsave_found", this.culture));
                    }

                }
            }
            else
            {
                this.view.Output(this.res_man.GetString("warning_toomuchsave", this.culture));
            }
        }
    }
}
