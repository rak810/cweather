using Newtonsoft.Json.Linq;

namespace cweather.WeatherData
{
    public class FeelsLikeData
    {
        public float Day;
        public float Night;
        public float Eve;
        public float Morn;

        public FeelsLikeData(JToken fTok)
        {
            Day = (float)fTok["day"];
            Night = (float)fTok["night"];
            Eve = (float)fTok["eve"];
            Morn = (float)fTok["morn"];
        }
    }
}