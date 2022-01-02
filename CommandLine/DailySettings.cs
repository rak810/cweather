using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace cweather.CommandLine
{
    [Description("Forecast next 6 days of weather")]
    public class DailySettings : ForecastSettings
    {
#nullable enable
        [Description("Location to forecast")]
        [CommandArgument(0, "[Location]")]
        public string? Location { get;  init; } 
#nullable disable
        [Description("0 is the current day. get forecast for day in [[1..6]]")]
        [CommandOption("-i|--index")]
        public int Index { get; init;}
        public override ValidationResult Validate()
        {
            if(Index < 1 || Index > 6) return ValidationResult.Error("Values from 1 to 6 is valid");
            return ValidationResult.Success();
        }
    }
}