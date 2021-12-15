using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace cweather.WeatherData
{
    public class WeatherFactors
    {
        public float Temp;
        public  float FeelsLike;
        public WindData Wind;
        public float Pressure;
        public float Humidity;
        public float DewPoint;
        public float Uvi;
        public float Clouds;
        public float Visibility;
        public List<WeatherDescription> weather;

        public WeatherFactors(JToken facTok)
        {
            Temp =  (float)facTok["temp"];
            FeelsLike = (float)facTok["feels_like"];
            Pressure = (float)facTok["pressure"];
            Humidity = (float)facTok["humidity"];
            DewPoint = (float)facTok["dew_point"];
            Uvi = (float)facTok["uvi"];
            Visibility = (float)facTok["visibility"];
            Wind = new WindData(facTok);
            weather.Add(new WeatherDescription(facTok["weather"].First));
        }
    }
}