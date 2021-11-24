using System;
using System.IO;
using System.Text.Json;

namespace EasySave_1_0.Model
{
    public class ModelLogLog : ModelLog  {
		private static EasySave_1_0.Model.ModelLogLog instance;
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

		public override void CreateLogFile() 
		{

			;
		}

		//Constructeur

		//string l_name, string l_fileSource, string l_fileTarget, DateTime l_timestamp, int l_fileSizes, int l_timeTransferts
		private ModelLogLog()
		{
			this.Name = l_name;
			this.FileSource = l_fileSource;
			this.FileTarget = l_fileTarget;
			this.Timestamp = l_timestamp;
			this.fileSize = l_fileSizes;
			this.timeTransfert = l_timeTransferts;
		}


		
		
		
		public static EasySave_1_0.Model.ModelLogLog GetInstance() {
			return this.instance;
		}


	}

}
