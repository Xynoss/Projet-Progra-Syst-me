using System.Globalization;
using System.Resources;

namespace Version_2._0.model
{
    public class ModelRessources
    {
        private ResourceManager res_man;
        private CultureInfo culture { set; get; }

        public ModelRessources()
        {
            culture = CultureInfo.CreateSpecificCulture("en");
            res_man = new RessourcesManager("EasySave_1_0.Properties.Res", typeof(ModelRessources).Assembly);
        }

        public string GetRessources()
        {
            return "ressources...";        }
    }
}
