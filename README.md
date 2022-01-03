# cweather

A CLI application written in C# to see weather of a location.
It uses two API services to fetch data from:

1. OpenWeatherMap  : [One call API](https://openweathermap.org/api/one-call-api)
2. Mapbox : [Geocoding API](https://docs.mapbox.com/api/search/geocoding/)

OpenWeatherMap one call API requires latitude and longtitude to return a result. So, Mapbox geocoding API is used to forward geocode a location string to latitude and longitude.

To show results in the terminal using tables, fancy colors and to parse the command line arguments, [Spectre.Console](https://spectreconsole.net/) library was used.

## How to run
This project is built using .NET5.  So it is needed to properly run the application.

 1. Clone the project
    ```
    git clone https://github.com/rak810/cweather.git
    ```
 2. Then cd into the project folder.
    ```
    cd .\cweather\
    ```
 3. Run build command 
   ```
   dotnet build
   ``` 
 4. The project will compile now. And run the exe from bin.
   ``` 
    cd .\bin\Debug\net5.0\ 
    .\cweather.exe --help
   ```