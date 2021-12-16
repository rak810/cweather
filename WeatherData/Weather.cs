using System.Collections.Generic;

namespace cweather.WeatherData
{
    public class Weather
    {
        public string TimeZone;
        public CurrentWeather Current;
        public List<DailyWeather> Daily;
        public List<HourlyWeather> Hourly;
        public Weather(
            string timeZone,
            CurrentWeather currentWeather,
            List<DailyWeather> dailyWeathers,
            List<HourlyWeather> hourlyWeathers)
        {
            TimeZone = timeZone;
            Current = currentWeather;
            Daily = dailyWeathers;
            Hourly = hourlyWeathers;
        }
    }
}