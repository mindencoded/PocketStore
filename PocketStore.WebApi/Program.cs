using Common.Logging;
using Microsoft.Owin.Hosting;
using System;
using System.Configuration;

namespace PocketStore.WebApi
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger<Program>();

        static void Main(string[] args)
        {
            
            var baseAddress = ConfigurationManager.AppSettings["BaseUri"];

            // Start OWIN host 
            using (WebApp.Start<Startup>(url: baseAddress))
            {
                Log.InfoFormat("Server running in: {0}", baseAddress);
                Console.ReadLine();
            }

           
        }
    }
}
