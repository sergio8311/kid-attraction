using System.Configuration;

namespace Attraction
{
    static class AttractionSettings
    {
        public static int GetMinimumHeightForBatman()
        {
            return int.Parse(ConfigurationManager.AppSettings["MinimumHeighForBatman"]);
        }

        public static int GetMinimumHeightForSwan()
        {
            return int.Parse(ConfigurationManager.AppSettings["MinimumHeighForSwan"]);
        }

        public static int GetMaximumHeightForSwan()
        {
            return int.Parse(ConfigurationManager.AppSettings["MaximumHeighForSwan"]);
        }

        public static int GetAttractionsCost()
        {
            return int.Parse(ConfigurationManager.AppSettings["AttractionCost"]);
        }
    }
}
