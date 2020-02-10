using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            var response = TflApi.DoApiStuff();
            DisplayBusStops(response);
           
        }
        private static void DisplayBusStops(List<BusStopObjects> response)
        {
            Console.WriteLine(response[0].stationName);
        }
    }
}