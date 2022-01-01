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
        public WeatherFactors wFacts;
        public float Precipitation;
        public float Rain;
        public float Snow;
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
            Precipitation = (float)dailyTok["pop"];

            if(dailyTok["rain"] != null) 
            {
                Rain = (float)dailyTok["rain"];
            }

            if(dailyTok["snow"] != null)
            {
                Snow = (float)dailyTok["snow"];
            }

            WDesc.Add(new WeatherDescription(dailyTok["weather"].First));
            wFacts = new WeatherFactors(dailyTok);
        }

        public string GetMoonPhaseName() => (double)MoonPhase switch
        {
            0 or 1 => "New Moon",
            0.25 => "First Quarter",
            0.50 => "Full Moon",
            0.75 => "Last Quarter",
            > 0 and < 0.25 => "Waxing Crescent",
            > 0.25 and < 0.50 => "Waxing Gibbous",
            > 0.50 and < 0.75 => "Waning Gibbous",
            > 0.75 and < 1 => "Waning Crescent",
            _ => throw new ArgumentOutOfRangeException($"{MoonPhase} isn't valid. Only value ranging from 0 to 1 is acceptable")
        };
    }
}