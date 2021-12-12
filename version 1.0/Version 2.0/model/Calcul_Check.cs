using System;
using System.IO;

namespace Version_2._0.model {
	/// <summary>
	/// Class to get the size of a file and the number of files in a folder.
	/// </summary>
	public class Calcul_Check {
		public Calcul_Check() {
		}
		/// <summary>
		/// Method to determine the file's size in a directory
		/// </summary>
		/// <param name="pathFile">Access path to the file.</param>
		/// <returns>Size of the file.</returns>
		public int FileSize(string pathFile)
		{
			//get the attribute for files or directory
			FileAttributes fileAtt = File.GetAttributes(pathFile);
			//check what is the attribut to know how to procced
			if ((fileAtt & FileAttributes.Directory) == FileAttributes.Directory)
            {
				//If it is a directory, search in all the directory to obtain the size
				DirectoryInfo dirInfo = new DirectoryInfo(pathFile);
				int folderSize = 0;
				foreach(FileInfo file in dirInfo.GetFiles("*", SearchOption.AllDirectories))
                {
					folderSize += (int)file.Length;
                }
				return folderSize;
            }
			//else, return the size of the file
			return (int)new FileInfo(pathFile).Length;
		}
		/// <summary>
		/// Method to determine the number of files in a folder
		/// </summary>
		/// <param name="pathFile">Access path to the file.</param>
		/// <returns>number of giles in a directory</returns>
		public int NbFiles(string pathFile)
        {
			return (int)Directory.GetFiles(pathFile, ".", SearchOption.AllDirectories).Length;
        }


	}

}
