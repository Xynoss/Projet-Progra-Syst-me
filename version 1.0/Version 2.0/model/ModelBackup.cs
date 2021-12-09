using EasySave_1_0.model;
using EasySave_1_0.Controller;
using System.Collections.Generic;

namespace Version_2._0.model
{
    public class ModelBackup
    {
        private List<ModelSave> list_saves;
        public List<ModelSave> List_saves
        {
            get
            {
                return list_saves;
            }
            set
            {
                list_saves = value;
            }
        }

        public ModelBackup()
        {
            getListSaves();
        }

        public List<ModelSave> getListSaves()
        {
            return this.list_saves; 
        }
    }
}
