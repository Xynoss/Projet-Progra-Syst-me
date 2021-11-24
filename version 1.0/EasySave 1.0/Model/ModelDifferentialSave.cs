using System;
using System.IO;

namespace EasySave_1_0.Model {
	public class ModelDifferentialSave : ModelSave  {
        public ModelDifferentialSave(string name, string sourcePath, string targetPath) : base(name, sourcePath, targetPath)
        {
        }

        /// <summary>
        /// methods to copy the files  
        /// </summary>
        public override void Save() {
            try
            {
                string[] fileList = Directory.GetFiles(sourcePath, "*");
                foreach (string f in fileList)
                {
                    filename = f.Substring(sourcePath.Length + 1);
                    File.Copy(Path.Combine(sourcePath, filename), Path.Combine(targetPath, filename));
                }

            }
            catch (DirectoryNotFoundException dirNotFound)
            {
                Console.WriteLine(dirNotFound.Message);
            }
        }

	}

}
