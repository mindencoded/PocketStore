using System;
using System.Configuration;
using Common.Logging;
using Microsoft.Owin.Hosting;

namespace SchoolExpress.WebService
{
    internal class Program
    {
        private static readonly ILog Log = LogManager.GetLogger<Program>();

        private static void Main(string[] args)
        {
            var baseAddress = ConfigurationManager.AppSettings["BaseUri"];
            // Start OWIN host 
            using (WebApp.Start<Startup>(baseAddress))
            {
                Log.InfoFormat("Server running in: {0}", baseAddress);
                Console.ReadLine();
            }
        }
    }
}