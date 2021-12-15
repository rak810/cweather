using System;
using Newtonsoft.Json.Linq;

namespace cweather.WeatherData
{
    public class DailyWeather
    {
        public DateTime Date;
        public DateTime SunRise;
        public DateTime SunSet;
        public DateTime MoonRise;
        public DateTime MoonnSet;
        public float MoonPhase;
        public TemperatureData Temp;
        public FeelsLikeData FeelsLike;
        public WeatherDescription WDesc;
        public float Precipitation;
        public DailyWeather(JToken dailyTok)
        {
            
        }
    }
}