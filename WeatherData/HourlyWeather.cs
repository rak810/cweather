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
#nullable enable
        public RainData? Rain;
        public SnowData? Snow;
#nullable disable
        public HourlyWeather(JToken hourTok)
        {
            WDesc =  new List<WeatherDescription>();
            Date = new DateTime(1970, 1, 1).AddSeconds((double)hourTok["dt"]).ToLocalTime();
            Precipitation = (float)hourTok["pop"];
            wFacts = new WeatherFactors(hourTok);
            Temp =  (float)hourTok["temp"];
            FeelsLike = (float)hourTok["feels_like"];

            if(hourTok["rain"] != null) 
            {
                Rain = new RainData(hourTok["rain"]);
            }

            if(hourTok["snow"] != null)
            {
                Snow = new SnowData(hourTok["snow"]);
            }
            WDesc.Add(new WeatherDescription(hourTok["weather"].First));
        }
    }
}