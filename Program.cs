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
            Env.Load();
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



