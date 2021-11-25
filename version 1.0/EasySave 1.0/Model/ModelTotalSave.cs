using System;
using System.IO;

namespace EasySave_1_0.Model {
	public class ModelTotalSave : ModelSave  {
        public ModelTotalSave(string name, string sourcePath, string targetPath) : base(name, sourcePath, targetPath)
        {
        }

        public override void Save() {
            try
            {
                string[] fileList = Directory.GetFiles(sourcePath, "*");
                foreach(string f in fileList)
                {
                    filename = f.Substring(sourcePath.Length + 1);
                    File.Copy(Path.Combine(sourcePath, filename), Path.Combine(targetPath,filename), true);
                }
                /*
                File.Create(sourcePath + "save_"+name+".conf");
                File.AppendText(sourcePath + "save_" + name + ".conf");*/
            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }
		}

	}*/

}
