using Spectre.Console;
using cweather.WeatherData;
using cweather.LocationData;

namespace cweather
{
    public class RenderWeatherData
    {
        private readonly Weather _weather;
        private readonly Location _location;
        // TODO: Location location, CurrentWeather currentWeather

        public RenderWeatherData(Weather weather, Location location)
        {
            _location = location;
            _weather = weather;
        }
        public void CurrentWeatherSummary()
        {
            string locationDetail = $"[bold blue] Location:[/] {_location.PlaceName} [[{_location.Coord.Lat}, {_location.Coord.Long}]]";
            AnsiConsole.MarkupLine(locationDetail);
            string timeDetail = $"[bold blue] Date:[/]{_weather.Current.Date.Date} [bold blue] Timezone:[/] {_weather.TimeZone}";
            AnsiConsole.MarkupLine(timeDetail);
            string wDetail = $"[bold blue] Weather:[/] {_weather.Current.WDesc[0].Main} / {_weather.Current.WDesc[0].Description}";
            AnsiConsole.MarkupLine(wDetail);
            AnsiConsole.MarkupLine($"[bold blue] Temperature:[/] {_weather.Current.Temp}ºC");
            AnsiConsole.MarkupLine($"[bold blue] Feels Like:[/] {_weather.Current.FeelsLike}ºC");
            string windDetail = $"[bold blue] Wind:[/] {_weather.Current.WFactors.Wind.WindSpeed} m/s, {_weather.Current.WFactors.Wind.WindDeg}º";
            AnsiConsole.MarkupLine(windDetail);
        }

        public void CurrentWeatherDetail()
        {
            CurrentWeatherSummary();
            var table = new Table();
            table.Border(TableBorder.Rounded);
            table.AddColumn(new TableColumn("Pressure").Centered());
            table.AddColumn(new TableColumn("Humidity").Centered());
            table.AddColumn(new TableColumn("Dew Point").Centered());
            table.AddColumn(new TableColumn("UVI").Centered());
            table.AddColumn(new TableColumn("Clouds").Centered());
            table.AddColumn(new TableColumn("Visibility").Centered());
            table.AddRow(
                $"{_weather.Current.WFactors.Pressure} hPa",
                $"{_weather.Current.WFactors.Humidity} %",
                $"{_weather.Current.WFactors.DewPoint}º C",
                $"{_weather.Current.WFactors.Uvi}",
                $"{_weather.Current.WFactors.Clouds} %",
                $"{_weather.Current.WFactors.Visibility} m"
            );
            // table.AddRow("Pressure", $"{_weather.Current.WFactors.Pressure}hPa");
            // table.AddRow("Humidity", $"{_weather.Current.WFactors.Humidity}%");
            // table.AddRow("Dew Point", $"{_weather.Current.WFactors.DewPoint}ºC");
            // table.AddRow("UVI", $"{_weather.Current.WFactors.Uvi}");
            // table.AddRow("Clouds", $"{_weather.Current.WFactors.Clouds}%");
            // table.AddRow("Visibility", $"{_weather.Current.WFactors.Visibility}m");
            AnsiConsole.Write(table);
        }
    }
}