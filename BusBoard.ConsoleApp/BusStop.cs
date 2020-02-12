using System.Collections.Generic;

namespace BusBoard
{
    public class BusStop
    {
        public string  naptanId { get; set; }
        public string commonName { get; set; }
        
    }

    public class BusData
    {
        public List<BusStop> stopPoints { get; set; }
    }
}