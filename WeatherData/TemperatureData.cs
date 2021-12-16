using Newtonsoft.Json.Linq;

namespace cweather.WeatherData
{
    public class TemperatureData
    {        
        public float Day;
        public float Night;
        public float Eve;
        public float Morn;
        public float Min;
        public float Max; 
        public TemperatureData(JToken tempTok)
        {
            Day = (float)tempTok["day"];
            Night = (float)tempTok["night"];
            Eve = (float)tempTok["eve"];
            Morn = (float)tempTok["morn"];
            Min = (float)tempTok["min"];
            Max = (float)tempTok["max"];
        }
    }
}