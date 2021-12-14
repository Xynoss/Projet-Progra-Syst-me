using EasySave_1_0.model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;


namespace EasySave_1_0.Controller
{
    public class Controller
    {

        private string save_name = "";

        private ResourceManager res_man;
        private CultureInfo culture;
        List<ModelLogState> lStates_tmp;
        private static List<EasySave_1_0.model.ModelLogState> states = new List<model.ModelLogState>();
        public static List<EasySave_1_0.model.ModelLogState> States
        {
            get { return states; }
            set { states = value; }
        }

        public List<ModelSave> saves;
        public List<ModelSave> Saves
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
        public Controller(List<EasySave_1_0.model.ModelSave> saves, EasySave_1_0.View.View view)
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

            this.view.Output(this.res_man.GetString("language_choose", this.culture));
            this.view.Output(this.res_man.GetString("language_en", this.culture));
            this.view.Output(this.res_man.GetString("language_fr", this.culture));
            Input_choise = this.view.Input();

            switch (Input_choise)
            {
                case "1"://choose the english language
                    culture = CultureInfo.CreateSpecificCulture("en");
                    this.view.Clearing();
                    this.view.Output(this.res_man.GetString("check_language", this.culture));

                    break;
                case "2"://choose the french language 
                    culture = CultureInfo.CreateSpecificCulture("fr");
                    this.view.Clearing();
                    this.view.Output(this.res_man.GetString("check_language", this.culture));
                    break;
            }
            this.view.Output(this.res_man.GetString("greeting", this.culture));
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
                        this.view.Clearing();
                        this.view.Output(this.res_man.GetString("save_complete_chosen", this.culture));
                        createTotal();
                        break;

                    case "2": //create a differential backup
                        this.view.Clearing();
                        this.view.Output(this.res_man.GetString("save_differential_chosen", this.culture));
                        createDifferential();
                        break;

                    case "3": //run all save
                        this.view.Clearing();
                        this.view.Output(this.res_man.GetString("run_all_save", this.culture));
                        for (byte i = 0; i < states.Count; i++)
                        {
                            ModelLogState current_states = states[i];
                            this.view.Output(string.Format(this.res_man.GetString("save_loading", this.culture), states[i].Name));
                            lStates_tmp = States;
                            this.saves[i].Save(ref current_states,ref lStates_tmp);
                            this.view.Clearing();
                            this.view.Output(string.Format(this.res_man.GetString("save_run", this.culture), states[i].Name));
                        }
                        break;

                    case "4": //run one save
                        this.view.Clearing();
                        this.view.Output(this.res_man.GetString("run_onesave", this.culture));
                        this.view.Output(this.res_man.GetString("choose_save", this.culture));
                        int nbsave = 0;
                        foreach (ModelSave save in this.saves)
                        {
                            this.view.Output(String.Format("{0} : {1}", nbsave, save.Name));
                            nbsave++;
                        }
                        int selected_save = int.Parse(this.view.Input());
                        ModelLogState correct_state = states[selected_save];
                        
                        this.view.Output(string.Format(this.res_man.GetString("save_loading", this.culture), saves[selected_save].Name));
                        lStates_tmp = States;
                        Saves[selected_save].Save(ref correct_state, ref lStates_tmp);
                        this.view.Clearing();
                        this.view.Output(string.Format(this.res_man.GetString("save_run", this.culture), saves[selected_save].Name));
                        break;
                }
            }

            this.view.Output(this.res_man.GetString("end", this.culture));

        }

        List<ModelSave> ListFoundSave = new List<ModelSave>();

        private void createTotal()
        {
            if (saves.Count < 6)
            {
                do
                {
                    this.view.Output(this.res_man.GetString("ask_name_save", this.culture));
                    save_name = this.view.Input();
                    ListFoundSave = saves.FindAll(x => x.Name == save_name);
                    if (ListFoundSave.Count > 0)
                    {
                        this.view.Output(this.res_man.GetString("warning_toomuchsave", this.culture));
                    }
                } while (ListFoundSave.Count != 0);
                this.view.Output(this.res_man.GetString("ask_source_path", this.culture));
                string save_sourcepath = this.view.Input();
                this.view.Output(this.res_man.GetString("ask_target_path", this.culture));
                string save_targetpath = this.view.Input();
                ModelSave currentSave = new ModelTotalSave(save_name, save_sourcepath, save_targetpath);
                saves.Add(currentSave);
                string SaveType = "Total";
                ModelLogState statefile = new ModelLogState(save_name, save_sourcepath, save_targetpath, SaveType);
                this.view.Output(string.Format(this.res_man.GetString("save_loading", this.culture), save_name));
                states.Add(statefile);
                lStates_tmp = States;
                currentSave.Save(ref statefile, ref lStates_tmp);
            }
            else
            {
                this.view.Output(this.res_man.GetString("ask_target_save", this.culture));
            }
            this.view.Clearing();
            this.view.Output(string.Format(this.res_man.GetString("save_created", this.culture), save_name));
        }

        private void createDifferential()
        {
            if (saves.Count < 6)
            {

                string save_sourcepath = "";
                string save_ref = "";
                do
                {
                    this.view.Output(this.res_man.GetString("ask_name_save", this.culture));
                    save_name = this.view.Input();
                    this.view.Output(this.res_man.GetString("choose_save_ref", this.culture));
                    save_ref = this.view.Input();

                    ListFoundSave = saves.FindAll(x => x.Name == save_ref);
                    if (ListFoundSave.Count > 0)
                    {
                        save_sourcepath = ListFoundSave[0].SourcePath;
                    }
                    else
                    {
                        this.view.Output(string.Format(this.res_man.GetString("notsave_found", this.culture), save_ref));
                    }

                } while (ListFoundSave.Count == 0);
                this.view.Output(this.res_man.GetString("ask_target_path", this.culture));
                string save_targetpath = this.view.Input();
                ModelSave modelSave = new model.ModelDifferentialSave(save_name, save_sourcepath, save_targetpath, String.Concat(ListFoundSave[0].TargetPath, save_ref, "/"));
                saves.Add(modelSave);
                string SaveType = "Diff";
                model.ModelLogState statefile = new model.ModelLogState(save_name, save_sourcepath, save_targetpath, SaveType);
                this.view.Output(string.Format(this.res_man.GetString("save_loading", this.culture), save_name));
                states.Add(statefile);
                lStates_tmp = States;
                modelSave.Save(ref statefile, ref lStates_tmp);
                this.view.Clearing();
                this.view.Output(string.Format(this.res_man.GetString("save_created", this.culture), save_name));
            }
            else
            {
                this.view.Output(this.res_man.GetString("warning_toomuchsave", this.culture));
            }
        }
    }
}
