using Spectre.Console;
using cweather.WeatherData;
using cweather.LocationData;
using System.Collections.Generic;
using Spectre.Console.Rendering;
using System;

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
            string timeDetail = $"[bold blue] Date:[/]{_weather.Current.Date} [bold blue] Timezone:[/] {_weather.TimeZone}";
            AnsiConsole.MarkupLine(timeDetail);
            string wDetail = $"[bold blue] Weather:[/] {_weather.Current.WDesc[0].Main} / {_weather.Current.WDesc[0].Description}";
            AnsiConsole.MarkupLine(wDetail);
            AnsiConsole.MarkupLine($"[bold blue] Temperature:[/] {_weather.Current.Temp}ºC");
            AnsiConsole.MarkupLine($"[bold blue] Feels Like:[/] {_weather.Current.FeelsLike}ºC");
            string windDetail = $"[bold blue] Wind:[/] {_weather.Current.WFactors.Wind.WindSpeed} m/s, {_weather.Current.WFactors.Wind.WindDeg}º";
            AnsiConsole.MarkupLine(windDetail);

            if(_weather.Hourly[0].Rain != null)
            {
                string rainDetail = $"[bold blue] Rain:[/] {_weather.Hourly[0].Rain.HourOne} mm";
                AnsiConsole.MarkupLine(rainDetail);
            }

            if(_weather.Hourly[0].Snow != null)
            {
                string snowDetail = $"[bold blue] Rain:[/] {_weather.Hourly[0].Snow.HourOne} mm";
                AnsiConsole.MarkupLine(snowDetail);
            }
        }

        public void CurrentWeatherDetail()
        {
            CurrentWeatherSummary();
            var table = new Table();
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
                $"{_weather.Current.WFactors.Visibility??=0} m"
            );

            AnsiConsole.Write(table);
        }

        public void ForecastHourlyWeather(int count)
        {
            var table = new Table();
            table.Title($"Forecast for next {count} hours");
            table.AddColumn(new TableColumn("Time").Centered());
            table.AddColumn(new TableColumn("Temp (Feels Like)").Centered());
            table.AddColumn(new TableColumn("Humidity").Centered());
            table.AddColumn(new TableColumn("Wind").Centered());
            table.AddColumn(new TableColumn("Description").Centered());

            for(int i = 1; i <= count; i++)
            {
                var row = RenderHourlyWeather(_weather.Hourly[i]);
                table.AddRow(row);
            }  

            AnsiConsole.Write(table);
        }

        private static TableRow RenderHourlyWeather(HourlyWeather hourlyWeather)
        {
            
            IEnumerable<IRenderable> wList = new List<IRenderable>{
                new Markup($"{hourlyWeather.Date.Day}/{hourlyWeather.Date.Month} {hourlyWeather.Date.ToShortTimeString()}"),
                new Markup($"{hourlyWeather.Temp}({hourlyWeather.FeelsLike}) ºC"),
                new Markup($"{hourlyWeather.wFacts.Humidity} %"),
                new Markup($"{hourlyWeather.wFacts.Wind.WindSpeed} m/s, ({hourlyWeather.wFacts.Wind.WindDeg}º)"),
                new Markup($"{hourlyWeather.WDesc[0].Description.ToUpper()}")
            };

            return new TableRow(wList);
        }

        public void ForecastDailyWeather(int i)
        {
            if(i > 6) {
                throw new ArgumentOutOfRangeException(nameof(i), $"Value must be between 1 and 6");
            }

            string locationDetail = $"[bold blue] Location:[/] {_location.PlaceName} [[{_location.Coord.Lat}, {_location.Coord.Long}]]";
            var table = new Table();
            table.Border(TableBorder.Double);
            table.Title = new TableTitle($"[bold blue] Forecast for {_weather.Daily[i].Date.ToLongDateString()}[/]");
            table.AddColumn(new TableColumn(string.Empty));
            table.HideHeaders();
            table.AddRow(new Markup(locationDetail));
            table.AddRow(new Markup($"[bold blue] Weather:[/] {_weather.Daily[i].WDesc[0].Main} / {_weather.Daily[i].WDesc[0].Description}"));
            table.AddRow(new Markup($"[bold blue] Max/Min temp: [/] {_weather.Daily[i].Temp.Max}ºC / {_weather.Daily[i].Temp.Min}ºC"));
            table.AddRow(new Markup($"[bold blue] Precipitation: [/] {_weather.Daily[i].Precipitation * 100}%"));
            if(_weather.Daily[i].Rain != null)
            {
                table.AddRow(new Markup($"[bold blue] Rain: [/] {_weather.Daily[i].Rain} mm"));
            }

            if(_weather.Daily[i].Snow != null)
            {
                table.AddRow(new Markup($"[bold blue] Snow: [/] {_weather.Daily[i].Snow} mm"));
            }
            table.AddRow(RenderDailyTemp(_weather.Daily[i]));
            table.AddRow(RenderDailyDetails(_weather.Daily[i]));
            AnsiConsole.Write(table);
            
        }

        private static Table RenderDailyDetails(DailyWeather dailyWeather)
        {
            var table = new Table();
            table.Centered();
            table.Title("Other Details");
            table.AddColumn(new TableColumn("Pressure").Centered());
            table.AddColumn(new TableColumn("Humidity").Centered());
            table.AddColumn(new TableColumn("Dew Point").Centered());
            table.AddColumn(new TableColumn("UVI").Centered());
            table.AddColumn(new TableColumn("Clouds").Centered());
            table.AddColumn(new TableColumn("Wind").Centered());

            table.AddRow(
                $"{dailyWeather.wFacts.Pressure} hPa",
                $"{dailyWeather.wFacts.Humidity} %",
                $"{dailyWeather.wFacts.DewPoint}º C",
                $"{dailyWeather.wFacts.Uvi}",
                $"{dailyWeather.wFacts.Clouds} %",
                $"{dailyWeather.wFacts.Wind.WindSpeed} m/s, ({dailyWeather.wFacts.Wind.WindDeg}º)"
            );
            return table;
        }


        private static Table RenderDailyTemp(DailyWeather dailyWeather)
        {
            var table = new Table();
            table.Title("Temperatures Across All Day");
            table.AddColumn(new TableColumn("Morning").Centered());
            table.AddColumn(new TableColumn("Day").Centered());
            table.AddColumn(new TableColumn("Evening").Centered());
            table.AddColumn(new TableColumn("Night").Centered());
        
            table.AddRow(new List<IRenderable>{
               new Markup($"[blue] Temperature:[/] {dailyWeather.Temp.Morn} ºC"),
               new Markup($"[blue] Temperature:[/] {dailyWeather.Temp.Day} ºC"),
               new Markup($"[blue] Temperature:[/] {dailyWeather.Temp.Eve} ºC"),
               new Markup($"[blue] Temperature:[/] {dailyWeather.Temp.Night} ºC")
            });

            table.AddRow(new List<IRenderable>{
               new Markup($"[blue] Feels Like:[/] {dailyWeather.FeelsLike.Morn} ºC"),
               new Markup($"[blue] Feels Like:[/] {dailyWeather.FeelsLike.Day} ºC"),
               new Markup($"[blue] Feels Like:[/] {dailyWeather.FeelsLike.Eve} ºC"),
               new Markup($"[blue] Feels Like:[/] {dailyWeather.FeelsLike.Night} ºC")
            });
            
            return table;
        }
    }
}