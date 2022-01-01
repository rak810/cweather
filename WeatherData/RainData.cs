using Newtonsoft.Json.Linq;

namespace cweather.WeatherData
{
    public class RainData
    {
       public float HourOne; 
       public RainData(JToken rTok)
       {
           HourOne = (float)rTok["1h"];
       }
    }

}