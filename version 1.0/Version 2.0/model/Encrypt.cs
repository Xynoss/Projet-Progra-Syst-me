﻿using EasySave_1_0.model;
using System.Collections.Generic;

namespace Version_2._0.model
{
    public class Encrypt
    {
        #region attribut
        private static List<string> listExt = new List<string>();
        public static List<string> ListExt
        {
            get { return listExt; }
            set { listExt = value; }
        }
        #endregion
        #region Méthode
        public static void SetExtensions()
        {
            listExt.Clear();   
            foreach (string s in Properties.Settings.Default.exToEnc)
            {
                listExt.Add(s);
            }
            ModelSave.ExToEnc = listExt;
        }
        #endregion
    }
}