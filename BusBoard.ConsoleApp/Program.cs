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
        static void Main()
        {
            //get input 
            //do something 
            //display something 
            
            var postcode = AskUserForPostCode();
            
            var postCodeDetails = PostcodeApi.GetPostCodeInfo(postcode);

            var nearestStop = TflApi.GetNearestBusStop(postCodeDetails.Result.Latitude, postCodeDetails.Result.Longitude);
            
            var nextBuses = TflApi.GetBuses(nearestStop.naptanId);
            
            PrintBusStopName(nearestStop);
            
            DisplayNextFiveBuses(nextBuses);
          
        }

        
        private static string AskUserForPostCode()
        {
            Console.WriteLine("Please enter your postcode: ");
            var userPostCode = Console.ReadLine();
            
            return userPostCode;
        }
        
        
        private static void PrintBusStopName(BusStop busStop)
        {
            Console.WriteLine("Welcome to Bus Stop: " + busStop.commonName);
        }
        
        
        private static void DisplayNextFiveBuses(List<BusArriveAtStop> response)
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