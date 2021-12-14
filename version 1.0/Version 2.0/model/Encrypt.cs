using EasySave_1_0.model;
using System.Collections.Generic;

namespace Version_2._0.model
{
    public class Encrypt
    {
        public static void SetExtensions()
        {
            List<string> listExt = new List<string>();
            foreach (string s in Properties.Settings.Default.exToEnc)
            {
                listExt.Add(s);
            }
            ModelSave.ExToEnc = listExt;
        }
    }
}