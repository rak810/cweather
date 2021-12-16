using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace cweather.WeatherData
{
    public class WeatherFactors
    {
        public WindData Wind;
        public float Pressure;
        public float Humidity;
        public float DewPoint;
        public float Uvi;
        public float Clouds;
        public float Visibility;

        public WeatherFactors(JToken facTok)
        {
            Pressure = (float)facTok["pressure"];
            Humidity = (float)facTok["humidity"];
            DewPoint = (float)facTok["dew_point"];
            Uvi = (float)facTok["uvi"];
            Visibility = (float)facTok["visibility"];
            Wind = new WindData(facTok);
        }
    }
}