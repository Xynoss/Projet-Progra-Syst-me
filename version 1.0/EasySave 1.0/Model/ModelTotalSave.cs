using System;
using System.IO;

namespace EasySave_1_0.model
{
    public class ModelTotalSave : ModelSave
    {
        public ModelTotalSave(string name, string sourcePath, string targetPath) : base(name, sourcePath, targetPath)
        {
        }

        public override void Save()
        {
            try
            {
                string[] fileList = Directory.GetFiles(sourcePath, "*");
                foreach (string f in fileList)
                {
                    filename = f.Substring(sourcePath.Length + 1);
                    File.Copy(Path.Combine(sourcePath, filename), Path.Combine(targetPath, filename), true);
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

        public override void LogState()
        {
            string log_name = this.name;
            DateTime log_timestamp = DateTime.Now;
            model.ModelLogState.GetInstance(log_name, this.sourcePath, this.targetPath, log_timestamp);
        }
        public override void LogLog()
        {
            string log_name = this.name;
            DateTime log_timestamp = DateTime.Now;
            model.ModelLogLog.GetInstance(log_name, filename, this.sourcePath, this.targetPath, log_timestamp);
        }

    }

}
