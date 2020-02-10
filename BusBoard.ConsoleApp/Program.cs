using System;
using RestSharp;
using RestSharp.Authenticators;

namespace BusBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("https://api.tfl.gov.uk");
            client.Authenticator = new HttpBasicAuthenticator("username","password");
            
            var request = new RestRequest("StopPoint/490008660N/Arrivals");

            var response = client.Get(request);
            
            Console.WriteLine(response.Content);
        }
    }
}