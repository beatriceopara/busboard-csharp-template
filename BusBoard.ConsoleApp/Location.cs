using System.ComponentModel.Design;

namespace BusBoard
{
    public class Location
    {
        public Result Result { get; set; }
    }

    public class Result
    {
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}