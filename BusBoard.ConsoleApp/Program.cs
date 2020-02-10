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
            var inputCode = BusCode();
            var response = TflApi.DoApiStuff(inputCode);
            BusStopName(response);
            DisplayBusStops(response);
            
        }

        private static string BusCode()
        {
            Console.Write("Please enter your stop code: ");
            var inputCode = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Here is the requested information for bus stop id " + inputCode);
            return inputCode;
            
        }
        
        private static void BusStopName(List<BusStopObjects> response)
        {
            Console.WriteLine("Welcome to Bus Stop: " + response[0].stationName);

        }
        
        
        private static void DisplayBusStops(List<BusStopObjects> response)
        {
            var allBuses = response;
            var firstFiveItems = response.Take(5);

            Console.WriteLine("Bus Name, Destination, Countdown");
            foreach (var bus in firstFiveItems)
            {
                Console.WriteLine($"{bus.lineName} {bus.destinationName} {bus.timeToStation}");
            }
            
        }

    }
}