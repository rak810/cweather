using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using DotNetEnv;
using System.Collections.Generic;
using cweather.ApiClient;
using cweather.LocationData;
using Newtonsoft.Json;
using cweather.WeatherData;
using System.IO;

// using Spectre.Console;

namespace cweather
{
    
    class Program
    {
        static async Task Main(string[] args)
        {
            Env.Load();

            var res = new ProcessQuery("dhaka");
            await res.ProcessWeatherData();

            // var jsonString = JsonConvert.SerializeObject(res.Weather);
            // await File.WriteAllTextAsync("weather.json", jsonString);

            var renderData = new RenderWeatherData(res.Weather, res.Location);
            renderData.CurrentWeatherDetail();
        }

        

    }

    
}
