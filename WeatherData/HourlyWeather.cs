using System;
using Newtonsoft.Json.Linq;

namespace cweather.WeatherData
{
    public class HourlyWeather
    {
        public DateTime Date;
        public float Precipitation;
        public WeatherFactors wFacts;
        public HourlyWeather(JToken hourTok)
        {
            Date = new DateTime((int)hourTok["dt"]);
            Precipitation = (float)hourTok["pop"];
            wFacts = new WeatherFactors(hourTok);
        }
    }
}