using Newtonsoft.Json.Linq;

namespace cweather.WeatherData
{
    public class WindData
    {
        public float WindSpeed;
        public float WindDeg;
        public float WindGust;
        public WindData(JToken windTok)
        {
            WindSpeed = (float)windTok["wind_speed"];
            WindDeg = (float)windTok["wind_deg"];
            WindGust = (float)windTok["wind_gust"];
        }
    }
}