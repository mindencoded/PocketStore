using System;
using System.Configuration;
using Common.Logging;
using Microsoft.Owin.Hosting;

namespace SchoolExpress.WebService
{
    public class RunService : IDisposable
    {
        private static readonly ILog Log = LogManager.GetLogger("TraceSourceApp");
        private IDisposable _app;

        public void Start()
        {
            try
            {
                string uri = ConfigurationManager.AppSettings["BaseUri"];
                _app = WebApp.Start<Startup>(uri);
                Log.InfoFormat("Server running in: {0}", uri);
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        public void Stop()
        {
            Dispose();
        }

        public void Dispose()
        {
            if (_app != null)
            {
                _app.Dispose();
            }
        }
    }
}