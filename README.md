# cweather

A CLI application written in C# to see weather of a location.
It uses two API services to fetch data from:

1. OpenWeatherMap  : [One call API](https://openweathermap.org/api/one-call-api)
2. Mapbox : [Geocoding API](https://docs.mapbox.com/api/search/geocoding/)

OpenWeatherMap one call API requires latitude and longtitude to return a result. So, Mapbox geocoding API is used to forward geocode a location string to latitude and longitude.