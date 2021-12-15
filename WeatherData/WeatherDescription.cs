using Newtonsoft.Json.Linq;

namespace cweather.WeatherData
{
    public class WeatherDescription
    {
        public int Id;
        public string Main;
        public string Description;
        public string Icon;

        public WeatherDescription(JToken wdTok)
        {
            Id = (int)wdTok["id"];
            Main = wdTok["main"].ToString();
            Description = wdTok["description"].ToString();
            Icon = wdTok["icon"].ToString();
        }
    }

}