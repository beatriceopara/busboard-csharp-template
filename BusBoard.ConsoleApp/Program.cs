using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Microsoft.VisualBasic;
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
            var allBuses = response;
            var firstFiveItems = response.Take(5);

            foreach (var bus in firstFiveItems)
            {
                Console.WriteLine(bus.destinationName);
            }
            
            // List<BusStopObjects> myBusList = new List<BusStopObjects>();
            
            // foreach (var buses in )
            // {
            //     
            // }
            //prints out the next 5 buses at our bus stop
            // Console.WriteLine(response[0].destinationName);
        }
    }
}