using EasySave_1_0.model;
using System;
using System.Collections.Generic;

namespace Version_2._0.ViewModel
{
    class CreateBackupModelView
    {
        #region attribut
        HomeViewModel viemmodelhome_save = HomeViewModel.getInstance();
        List<ModelSave> ListFoundSave = new List<ModelSave>();
        #endregion

        #region constructeur
        public CreateBackupModelView() { }
        #endregion

        #region Méthode
        public void CreateComp(string name, string sourcePath, string targetPath)
        {
            ListFoundSave = viemmodelhome_save.saves.FindAll(x => x.Name == name);
            if (ListFoundSave.Count <= 0)
            {
                ModelSave Save = new ModelTotalSave(name, sourcePath, String.Concat(targetPath, "\\"));
                viemmodelhome_save.Saves.Add(Save);
                ModelLogState toState = Save.ToState();
                toState.SaveRef = "Total";
                viemmodelhome_save.States.Add(toState);
                List<ModelLogState> fullListStates = viemmodelhome_save.States;
                Save.Save(ref toState, ref fullListStates);
            }

        }

        public void CreateDiff(string name, string sourcePath, string targetPath, string refSave)
        {
            List<ModelSave> ListFoundSave = new List<ModelSave>();
            ListFoundSave = viemmodelhome_save.saves.FindAll(x => x.Name == refSave);
            if (ListFoundSave.Count > 0)
            {
                sourcePath = ListFoundSave[0].SourcePath;
            }

            ModelSave Save = new ModelDifferentialSave(name, sourcePath, String.Concat(targetPath,"\\"), String.Concat(ListFoundSave[0].TargetPath, "/", refSave, "/"));
            viemmodelhome_save.Saves.Add(Save);
            ModelLogState toState = Save.ToState();
            toState.SaveRef = "Diff";
            viemmodelhome_save.States.Add(toState);
            List<ModelLogState> fullListStates = viemmodelhome_save.States;
            Save.Save(ref toState, ref fullListStates);
        }

        public List<ModelSave> SaveExisted()
        {
            List<ModelSave> SaveExisted = new List<ModelSave>();
            SaveExisted = viemmodelhome_save.Saves;
            return SaveExisted;
        }
        #endregion
    }
}
