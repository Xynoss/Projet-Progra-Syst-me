using System.Globalization;
using System.Resources;
using EasySave_1_0.Controller;

namespace Version_20.model
{
    public class ModelRessources
    {
        private ResourceManager res_man;
        private CultureInfo culture { set; get; }

        public ModelRessources()
        {
            culture = CultureInfo.CreateSpecificCulture("en");
            res_man = new ResourceManager("EasySave_1_0.Properties.Res", typeof(Controller).Assembly);
        }

        public string GetRessources(string s)
        {
            return res_man.GetString(s, culture);
        }
    }
}
