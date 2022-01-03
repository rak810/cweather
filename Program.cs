using System;
using System.Text;
using System.Threading.Tasks;
using DotNetEnv;
using Spectre.Console.Cli;
using cweather.CommandLine;

namespace cweather
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // Loading environmental variables from .env file
            Env.Load();
            // Setting text encoding of the terminal to utf8 to render everything properly
            Console.OutputEncoding = Encoding.UTF8;
            
            //Commandline parsing
            var app = new CommandApp();
            app.Configure(config =>
            {
                config.AddBranch<ForecastSettings>("fcast", fcast =>
                {
                    fcast.AddCommand<DailyCommand>("daily");
                    fcast.AddCommand<HourlyCommand>("hourly");
                });

                config.AddCommand<SetCommand>("set");
                config.AddCommand<CurrCommand>("curr");
            }
            );
            
            await app.RunAsync(args);

        }
    }
}
