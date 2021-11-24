using System;
using System.IO;

namespace Model {
	public class ModelLogLog : ModelLog  {
		private int fileSize;
		public int FileSize {
			get {
				return fileSize;
			}
			set {
				fileSize = value;
			}
		}
		private int timeTransfert;
		public int TimeTransfert {
			get {
				return timeTransfert;
			}
			set {
				timeTransfert = value;
			}
		}

<<<<<<< Updated upstream
		private MapperClass.MapperLog mapperLog;
		private LogClass.CreateLogLog createLogLog;
=======

		public override void CreateLogFile() {
		// Vérifiez si le fichier existe déjà. Si oui, supprimez-le.    
		if (File.Exists(PathLog))
		{
			File.Delete(PathLog);
		}

		// Créer un nouveau fichier   
		using (FileStream fileStr = File.Create(PathLog)) ;

	}
	public override void WriteLog() {

		if (File.Exists(PathLog))
		{


			using (StreamWriter sw = File.AppendText(PathLog))
			{
				sw.WriteLine(message);

			}
		}
		else
        {
			using (StreamWriter sw = File.CreateText(PathLog))
			{
				sw.WriteLine(message);
				
			}

		}

		}
		private ModelLogLog() {
			throw new System.NotImplementedException("Not implemented");
		}
		public static EasySave_1.0.Model.ModelLogLog GetInstance() {
			return this.instance;
		}

		private Calcul_Check 0_*;
>>>>>>> Stashed changes

	}

}
