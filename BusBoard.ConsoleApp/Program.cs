using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
            var busStopCode = GetBusStopCode();
            var response = TflApi.GetBusStopInfo(busStopCode);
            //if response is valid then continue 
            //else request new bus stop code 

            
            if (response[0].destinationName == null)
            {
                Console.WriteLine("Invalid bus stop code entered, please re-enter valid stop code");
                
            }
            else
            {
                PrintBusStopName(response);
                DisplayNextFiveBuses(response); 
            }
        }

        private static string GetBusStopCode()
        {
            Console.Write("Please enter your stop code: ");
            var busStopCode = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Here is the requested information for bus stop id " + busStopCode);
            return busStopCode;
        }
        
        private static void PrintBusStopName(List<BusStopObjects> response)
        {
            Console.WriteLine("Welcome to Bus Stop: " + response[0].stationName);
        }
        
        
        private static void DisplayNextFiveBuses(List<BusStopObjects> response)
        {
            var firstFiveItems = response.Take(5);

            Console.WriteLine("Bus Number | Destination | Countdown");
            foreach (var bus in firstFiveItems)
            {
                Console.WriteLine($"{bus.lineName} {bus.destinationName} {bus.timeToStation/60} mins");
                /*
                divide time value by 60
                https://stackoverflow.com/questions/10935459/coverting-int-to-decimal-following-mm-ss-format
                https://stackoverflow.com/questions/3665012/how-to-convert-seconds-in-minsec-format/43282139
                */
            }
            
        }

    }
}