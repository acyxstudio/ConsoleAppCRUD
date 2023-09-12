using System;
using System.Net.Http;
using Microsoft.Owin.Hosting;

namespace ConsoleAppCRUD
{
    public class Program
    {
        static void Main()
        {
            string baseAddress = "http://localhost:7000/";

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                // Create HttpClient and make a request to api/values 
                HttpClient client = new HttpClient();

                var response = client.GetAsync(baseAddress + "api/values").Result;

                Console.WriteLine("Server is running at " ,response);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                Console.WriteLine("Press Enter to exit...");
                Console.ReadLine();
            }
        }
    }
}
