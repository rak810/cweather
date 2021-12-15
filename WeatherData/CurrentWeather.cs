using System;

namespace cweather.WeatherData
{
    public class CurrentWeather
    {
        public DateTime Date;
        public DateTime SunRise;
        public DateTime Sunset;
        public float Temp;
        public  float FeelsLike;
        public WeatherFactors WFactors;
        public WindData Wind;
        public WeatherDescription[] weather;
    }
  
}