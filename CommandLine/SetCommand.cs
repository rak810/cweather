using System.ComponentModel;
using System.Threading.Tasks;
// using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.Console.Cli;

namespace cweather.CommandLine
{
    [Description("Set locattion or tokens")]
    public class SetCommand : AsyncCommand<SetCommand.Settings>
    {
        public class Settings : CommandSettings
        {
#nullable enable
            [CommandOption("-l|--location")]
            [Description("Set Default location")]
            public string? Location { get; init; }

            [CommandOption("-o|--own-token")]
            [Description("Set Open Weather Map Token")]
            public string? OwmToken { get; init; }

            [CommandOption("-m|--mapbx-token")]
            [Description("Set Mapbox Token")]
            public string? MapboxToken { get; init; }
#nullable disable
        }

        public override Task<int> ExecuteAsync(CommandContext context, Settings settings)
        {
            if(settings.Location != null)
            {
                AnsiConsole.MarkupLine($"[bold blue] Location: [/] {settings.Location}");
            }

            if(settings.OwmToken != null)
            {
                AnsiConsole.MarkupLine($"[bold blue] OwmToken: [/] {settings.OwmToken}");
            }

            if(settings.MapboxToken != null)
            {
                AnsiConsole.MarkupLine($"[bold blue] MapboxToken: [/] {settings.MapboxToken}");
            }

            return Task.FromResult(0);
        }
    }

}