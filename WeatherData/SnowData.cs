using Newtonsoft.Json.Linq;

namespace cweather.WeatherData
{
    public class SnowData
    {
        public float HourOne; 
        
        public SnowData(JToken sTok)
        {
            HourOne = (float)sTok["1h"];
        }
    }
}