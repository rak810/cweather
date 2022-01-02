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
            Env.Load();
            Console.OutputEncoding = Encoding.UTF8;
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



// using Spectre.Console;

// Synchronous
// await AnsiConsole.Status()
//     .StartAsync("Thinking...", async ctx => 
//     {
//         ctx.Spinner(Spinner.Known.Circle);
//         // Simulate some work
//         AnsiConsole.MarkupLine("Doing some work...");
//         await Task.Delay(3000);
        
//         // Update the status and spinner
        
//         ctx.Status("Thinking some more");

//         // Simulate some work
//         AnsiConsole.MarkupLine("Doing some more work...");
//         await Task.Delay(4000);
//     });

// Console.WriteLine(10);