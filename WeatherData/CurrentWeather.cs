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
        public CurrentWeather(JToken currTok)
        {
            Date = (DateTime)currTok["dt"];
            SunRise = (DateTime)currTok["sunrise"];
            Sunset = (DateTime)currTok["sunset"];
            WFactors = new WeatherFactors(currTok);
        }
    }
  
}