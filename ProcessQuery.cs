using cweather.WeatherData;
using cweather.LocationData;
using cweather.ApiClient;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using Spectre.Console;

namespace cweather
{
    public class ProcessQuery
    {
        private JObject _weatherJsonObject;
        private Weather _weather;
        public Weather Weather => _weather;
        private Location _location;
        public Location Location => _location;
        private readonly SimpleMapBoxApiClient _mpApi;
        private readonly OpenWeatherApiClient _opApi;
        private readonly string _queryLoc;
        public ProcessQuery(string queryLoc)
        {
            _queryLoc = queryLoc;
            _mpApi = new SimpleMapBoxApiClient();
            _opApi = new OpenWeatherApiClient();
        }

        private async Task GetLocationAsync()
        {
            var res = await _mpApi.GetLatLongAsync(_queryLoc);
            _location = new Location(res);
        }

        private async Task GetWeatherJsonAsync()
        {
            _weatherJsonObject = await _opApi.GetWeatherAsync(_location);

        }

        public  async Task ProcessWeatherData()
        {
            await AnsiConsole.Status()
                             .StartAsync("Fetching Data... ", async ctx => 
                             {
                                ctx.Spinner(Spinner.Known.Dots2);
                                await GetLocationAsync();
                                await GetWeatherJsonAsync();
                             });
            

            var currentWeather = new CurrentWeather(_weatherJsonObject.SelectToken("current"));

            var hourlyWeathers = ProcessData(
                _weatherJsonObject.SelectToken("hourly"), 
                (tempTok) => new HourlyWeather(tempTok)
            );

            var dailyWeathers = ProcessData(
                _weatherJsonObject.SelectToken("daily"), 
                (tempTok) => new DailyWeather(tempTok)
            );

            _weather = new Weather(
                _weatherJsonObject.SelectToken("timezone").ToString(), 
                currentWeather, 
                dailyWeathers, 
                hourlyWeathers
            );
        }

        private static List<T> ProcessData<T>(JToken hourlyTok, Func<JToken, T> consFunc)
        {
            var dataList = new List<T>();
            foreach (var item in hourlyTok)
            {
                var temp = consFunc(item);
                dataList.Add(temp);
            }

            return dataList;
        }
    }
}