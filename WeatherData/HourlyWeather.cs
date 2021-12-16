using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace cweather.WeatherData
{
    public class HourlyWeather
    {
        public DateTime Date;
        public float Precipitation;
        public float Temp;
        public  float FeelsLike;
        public WeatherFactors wFacts;
        public List<WeatherDescription> WDesc;
        public HourlyWeather(JToken hourTok)
        {
            WDesc =  new List<WeatherDescription>();
            Date = new DateTime((long)hourTok["dt"]);
            Precipitation = (float)hourTok["pop"];
            wFacts = new WeatherFactors(hourTok);
            Temp =  (float)hourTok["temp"];
            FeelsLike = (float)hourTok["feels_like"];
            WDesc.Add(new WeatherDescription(hourTok["weather"].First));
        }
    }
}