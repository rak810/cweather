using System.Diagnostics.CodeAnalysis;
using Spectre.Console.Cli;
using System.ComponentModel;
using Spectre.Console;
using System.Threading.Tasks;
using System;

namespace cweather.CommandLine
{
    [Description("Get the current weather information")]
    public class CurrCommand : AsyncCommand<CurrCommand.Settings>
    {
        public class Settings : CommandSettings
        {
            [Description("Displays detailed current weather")]
            [CommandOption("-d|--detail")]
            public bool Detail { get; init; }
#nullable enable      
            [Description("Name of the location")]
            [CommandArgument(0, "[Name]")]
            public string? Location { get; init; }
#nullable disable
        }
        
        public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
        {
            if (settings.Location != null)
            {
                var res = new ProcessQuery(settings.Location);
                await res.ProcessWeatherData();
                var renderData = new RenderWeatherData(res.Weather, res.Location);
                if(settings.Detail)
                {
                    renderData.CurrentWeatherDetail();
                    return 0;
                }
                renderData.CurrentWeatherSummary();
            }

            return 0;
        }
    }
}