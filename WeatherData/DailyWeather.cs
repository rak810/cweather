using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace cweather.WeatherData
{
    public class DailyWeather
    {
        public DateTime Date;
        public DateTime SunRise;
        public DateTime SunSet;
        public DateTime MoonRise;
        public DateTime MoonSet;
        public float MoonPhase;
        public TemperatureData Temp;
        public FeelsLikeData FeelsLike;
        public List<WeatherDescription> WDesc;
        public float Precipitation;
        public DailyWeather(JToken dailyTok)
        {
            WDesc =  new List<WeatherDescription>();
            Date = new DateTime(1970, 1, 1).AddSeconds((double)dailyTok["dt"]).ToLocalTime();
            SunRise = new DateTime(1970, 1, 1).AddSeconds((double)dailyTok["sunrise"]).ToLocalTime();
            SunSet = new DateTime(1970, 1, 1).AddSeconds((double)dailyTok["sunset"]).ToLocalTime();
            MoonRise = new DateTime(1970, 1, 1).AddSeconds((double)dailyTok["moonrise"]).ToLocalTime();
            MoonSet = new DateTime(1970, 1, 1).AddSeconds((double)dailyTok["moonset"]).ToLocalTime();
            MoonPhase = (float)dailyTok["moon_phase"];
            Temp = new TemperatureData(dailyTok["temp"]);
            FeelsLike = new FeelsLikeData(dailyTok["feels_like"]);
            WDesc.Add(new WeatherDescription(dailyTok["weather"].First));
        }
    }
}