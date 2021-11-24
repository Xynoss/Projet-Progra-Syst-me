using System;
using System.IO;

namespace Model {
	public class ModelLogState : ModelLog  {
		private bool state;
		private int totalFileToCopy;
		public int TotalFileToCopy {
			get {
				return totalFileToCopy;
			}
			set {
			totalFileToCopy = value;
			}
		}
		private int totalFileSize;
		public int TotalFileSize {
			get {
				return totalFileSize;
			}
			set {
				totalFileSize = value;
			}
		}
		private int progression;
		public int Progression {
			get {
				return progression;
			}
			set {
				progression = value;
			}
		}
		private int nbFilesLeft;
		public int NbFilesLeft {
			get {
				return nbFilesLeft;
			}
			set {
				nbFilesLeft = value;
			}
		}
<<<<<<< Updated upstream

		private MapperClass.MapperState mapperState;
		private LogClass.CreateLogState createLogState;

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
		private ModelLogState() {
			throw new System.NotImplementedException("Not implemented");
		}
		public static ModelLogState GetInstance() {
			return this.instance;
		}

    

    

    private Calcul_Check 0_*;
>>>>>>> Stashed changes
	}

}
