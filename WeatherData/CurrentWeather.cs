using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace cweather.WeatherData
{
    public class CurrentWeather
    {
        public DateTime Date;
        public DateTime SunRise;
        public DateTime Sunset;
        public WeatherFactors WFactors;
        public float Temp;
        public  float FeelsLike;
        public List<WeatherDescription> WDesc;
        public CurrentWeather(JToken currTok)
        {
            WDesc =  new List<WeatherDescription>();
            Date = new DateTime(1970, 1, 1).AddSeconds((double)currTok["dt"]).ToLocalTime();
            SunRise = new DateTime(1970, 1, 1).AddSeconds((double)currTok["sunrise"]).ToLocalTime();
            Sunset = new DateTime(1970, 1, 1).AddSeconds((double)currTok["sunset"]).ToLocalTime();
            WDesc.Add(new WeatherDescription(currTok["weather"].First));
            WFactors = new WeatherFactors(currTok);
            Temp =  (float)currTok["temp"];
            FeelsLike = (float)currTok["feels_like"];
        }
    }
  
}