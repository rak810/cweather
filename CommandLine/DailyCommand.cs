using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Spectre.Console;
using Spectre.Console.Cli;

namespace cweather.CommandLine
{
    [Description("Forecast next 6 days of weather")]
    public class DailyCommand : AsyncCommand<DailySettings>
    {
        public override async Task<int> ExecuteAsync(CommandContext context, DailySettings settings)
        {
            if(settings.Location != null)
            {
                var res = new ProcessQuery(settings.Location);
                await res.ProcessWeatherData();
                var renderData = new RenderWeatherData(res.Weather, res.Location);
                renderData.ForecastDailyWeather(settings.Index);
            }
            return 0;
        }

    }
}