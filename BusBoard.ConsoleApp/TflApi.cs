using System.Collections.Generic;
using RestSharp;

namespace BusBoard
{
    public class TflApi
    {
        public static List<BusStopObjects> DoApiStuff()
        {
            var client = new RestClient("https://api.tfl.gov.uk");
            var request = new RestRequest("StopPoint/490008660N/Arrivals");
            List<BusStopObjects> response = client.Get<List<BusStopObjects>>(request).Data;

            return response;
        }
    }
}