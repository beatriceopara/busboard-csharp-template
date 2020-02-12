using System.Collections.Generic;
using RestSharp;

namespace BusBoard
{
    public class TflApi
    {
        public static List<BusArriveAtStop> GetBuses(string inputCode)
        {
            var client = new RestClient("https://api.tfl.gov.uk");
            var request = new RestRequest($"StopPoint/{inputCode}/Arrivals");
            List<BusArriveAtStop> response = client.Get<List<BusArriveAtStop>>(request).Data;

            return response;
        }

        public static BusStop GetNearestBusStop(string latitude, string longitude)
        {
            var client = new RestClient("https://api.tfl.gov.uk");
            var request = new RestRequest($"StopPoint?stopTypes=NaptanPublicBusCoachTram&lat={latitude}&lon={longitude}");
            BusData response = client.Get<BusData>(request).Data;
            
            return response.stopPoints[0];
        }
    }
}