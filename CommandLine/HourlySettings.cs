using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;
namespace cweather.CommandLine
{
    public class HourlySettings : ForecastSettings
    {
#nullable enable
        [Description("Location to forecast")]
        [CommandArgument(0, "[Location]")]
        public string? Location { get;  init; } 
#nullable disable
        [Description("Count of hours for forecast")]
        [CommandOption("-r|--range")]
        public int Range { get; init;}

        public override ValidationResult Validate()
        {
            if(Range < 1 || Range > 10) return ValidationResult.Error("Values from 1 to 10 is valid");
            return ValidationResult.Success();
        }
    }
}