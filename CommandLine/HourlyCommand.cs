using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Spectre.Console;
using Spectre.Console.Cli;

namespace cweather.CommandLine
{
    [Description("Forecast next 10 hours of weather")]
    public class HourlyCommand : AsyncCommand<HourlySettings>
    {
        
        public override async Task<int> ExecuteAsync(CommandContext context, HourlySettings settings)
        {
            if(settings.Location != null)
            {
                var res = new ProcessQuery(settings.Location);
                await res.ProcessWeatherData();
                var renderData = new RenderWeatherData(res.Weather, res.Location);
                renderData.ForecastHourlyWeather(settings.Range);
            }
            return 0;
        }
    }
}