using System;

namespace Model {
	public class ModelTotalSave : ModelSave  {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="sourcePath"></param>
        /// <param name="targetPath"></param>
        public ModelTotalSave(ref string name, ref string sourcePath, ref string targetPath) : base(ref name, ref sourcePath, ref targetPath)
        {
            try
            {

            }catch
            {

            }
        }

        public override void Save() {
			throw new System.NotImplementedException("Not implemented");
		}

	}

}
