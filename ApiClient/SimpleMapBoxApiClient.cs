using System.Net.Http;
using System.Net;
using DotNetEnv;
using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace cweather.ApiClient
{
    public class SimpleMapBoxApiClient : IDisposable
    {
        private readonly HttpClient _httpClient;
        private readonly string _mbApiToken;
        private bool disposedValue;

        public SimpleMapBoxApiClient(string apiKey)
       {
           _httpClient = new HttpClient();
           _mbApiToken = apiKey;
       }
        public SimpleMapBoxApiClient()
        {
            _httpClient = new HttpClient();
           _mbApiToken = Env.GetString("MBapiToken");  
        }

        private Uri GenerateReqUrl(string loc) => new($"https://api.mapbox.com/geocoding/v5/mapbox.places/{WebUtility.UrlEncode(loc)}.json?access_token={_mbApiToken}");

        public async Task<JToken> GetLatLongAsync(string loc)
        {
            var reqUri = GenerateReqUrl(loc);
            JToken locationObj = null;

            try
            {
                 var response = await _httpClient.GetAsync(reqUri);

                 if(response.IsSuccessStatusCode)
                 {
                     var jsonStr = await response.Content.ReadAsStringAsync();
                     var jsonDict = JObject.Parse(jsonStr);
                     locationObj = jsonDict.SelectToken("features").First;
                    //  var res = jsonDict.SelectToken("features");
                 }
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Error in MapApiClient : {e.Message}");
                throw;
            }

            return locationObj;
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
        // ~SimpleMapBoxApiClient()
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