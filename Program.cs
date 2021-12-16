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

namespace cweather
{
    
    class Program
    {
        // static async void Main(string[] args)
        // {
        //     // Create a root command 

        //     // var rootCommand = new CmdLine();

        //     // return rootCommand.CreateCmdLine(args).Result;
        //    string loc = await ApiRequest.RunAsync("dhaka");
        //    System.Console.WriteLine(loc);

        // }
        static async Task Main(string[] args)
        {
            Env.Load();

            var res = new ProcessQuery("dhaka");
            await res.ProcessWeatherData();

            var jsonString = JsonConvert.SerializeObject(res.Weather);
            await File.WriteAllTextAsync("weather.json", jsonString);

            // var mpApi = new SimpleMapBoxApiClient();
            // var res = await mpApi.GetLatLongAsync("dhaka");
            // var loc = new Location(res);


            // Console.WriteLine($"PlaceName : {loc.PlaceName}");
            // Console.WriteLine($"Lat : {loc.Coord.Lat}");
            // Console.WriteLine($"Long : {loc.Coord.Long}");

            // var opApi = new OpenWeatherApiClient();
            // var opRes = await opApi.GetWeatherAsync(loc);
            // Console.WriteLine(opRes);

            // int i = 0;
            // foreach (var item in res.Children())
            // {
            //     if(i < 1) {
            //         Console.WriteLine(item);
            //     }
            //     else {
            //         break;
            //     }
            //     i++;
            // }
        }

    }

    
}
