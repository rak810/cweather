using System;
using System.Net.Http;
using DotNetEnv;
using System.Threading.Tasks;
using cweather.LocationData;
using Newtonsoft.Json.Linq;

namespace cweather.ApiClient
{
    public class OpenWeatherApiClient : IDisposable
    {
       private readonly HttpClient _httpClient;
       private readonly string _owmApiToken;
        private bool disposedValue;

        public OpenWeatherApiClient(string apiKey)
       {
           _httpClient = new HttpClient();
           _owmApiToken = apiKey;
       }
       public OpenWeatherApiClient()
       {
           _httpClient = new HttpClient();
           _owmApiToken = Env.GetString("OWMapiToken");     
       }

        private Uri GenerateReqUrl(float Lat, float Long) => new($"https://api.openweathermap.org/data/2.5/onecall?lat={Lat}&lon={Long}&units=metric&exclude=minutely&appid={_owmApiToken}");

        public async Task<JObject> GetWeatherAsync(Location loc)
        {
            var reqUri = GenerateReqUrl(loc.Coord.Lat, loc.Coord.Long);
            JObject weatherObj = null;

            try
            {
                 var response = await _httpClient.GetAsync(reqUri);

                 if(response.IsSuccessStatusCode)
                 {
                     var jsonStr = await response.Content.ReadAsStringAsync();
                     var jsonDict = JObject.Parse(jsonStr);
                     weatherObj = jsonDict;
                    //  var res = jsonDict.SelectToken("features");
                 }
                 else 
                 {
                     Console.WriteLine($"Request Failed. {response.RequestMessage}");
                 }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Error in OPApiClient : {e.Message}");
                throw;
            }

            return weatherObj;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~OpenWeatherApiClient()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}