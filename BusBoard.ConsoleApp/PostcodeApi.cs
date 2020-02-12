using System.Collections.Generic;
using RestSharp;

namespace BusBoard
{
    public class PostcodeApi
    {
        public static Location GetPostCodeInfo(string postcode)
        {
            var client = new RestClient("https://api.postcodes.io");
            var request = new RestRequest($"postcodes/{postcode}");
            Location response = client.Get<Location>(request).Data;

            return response;
        }
    }
}