using Newtonsoft.Json.Linq;

namespace cweather.LocationData
{
    public class Location
    {
        public string PlaceName { get; }
        public (float Lat, float Long) Coord;

        public Location(JToken token)
        {
            PlaceName = token.SelectToken("place_name").ToString();
            Coord.Long = (float)token.SelectToken("center").First;
            Coord.Lat = (float)token.SelectToken("center").Last;
        }
    }

}