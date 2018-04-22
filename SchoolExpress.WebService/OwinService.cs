using System;
using Common.Logging;
using Microsoft.Owin.Hosting;

namespace SchoolExpress.WebService
{
    public class Service
    {
        private static readonly ILog Log = LogManager.GetLogger<Service>();
        private IDisposable _app;
        private string _url; 

        public Service(string url)
        {
            _url = url;
        }

        public void Start()
        {
            try
            {
                _app = WebApp.Start<Startup>(_url);
                Log.InfoFormat("Server running in: {0}", _url);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }

        }

        public void Stop()
        {
            try
            {
                _app.Dispose();
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}