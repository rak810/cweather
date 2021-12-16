using Newtonsoft.Json.Linq;

namespace cweather.WeatherData
{
    public class WindData
    {
        public float WindSpeed;
        public float WindDeg;
        public float? WindGust;
        public WindData(JToken windTok)
        {
            WindSpeed = (float)windTok["wind_speed"];
            WindDeg = (float)windTok["wind_deg"];
            if(windTok["wind_gust"] == null)
            {
                WindGust = null;
            }
            else 
            {
                WindGust = (float)windTok["wind_gust"];
            }
        }
    }
}