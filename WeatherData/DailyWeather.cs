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
            Date = new DateTime((long)dailyTok["dt"]);
            SunRise = new DateTime((long)dailyTok["sunrise"]);
            SunSet = new DateTime((long)dailyTok["sunset"]);
            MoonRise = new DateTime((long)dailyTok["moonrise"]);
            MoonSet = new DateTime((long)dailyTok["moonset"]);
            MoonPhase = (float)dailyTok["moon_phase"];
            Temp = new TemperatureData(dailyTok["temp"]);
            FeelsLike = new FeelsLikeData(dailyTok["feels_like"]);
            WDesc.Add(new WeatherDescription(dailyTok["weather"].First));
        }
    }
}