using System.Collections.Generic;
using RestSharp;

namespace BusBoard
{
    public class TflApi
    {
        public static List<BusStopObjects> DoApiStuff(string inputCode)
        {
            var client = new RestClient("https://api.tfl.gov.uk");
            var request = new RestRequest($"StopPoint/{inputCode}/Arrivals");
            List<BusStopObjects> response = client.Get<List<BusStopObjects>>(request).Data;

            return response;
        }
    }
}