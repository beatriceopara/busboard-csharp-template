using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://api.tfl.gov.uk");
            var request = new RestRequest("StopPoint/490008660N/Arrivals");
            List<BusStopObjects> response = client.Get<List<BusStopObjects>>(request).Data;

            Console.WriteLine(response[0].stationName);
        }
    }
}