using System;
using System.Configuration;
using System.Diagnostics;
using Common.Logging;
using Microsoft.Owin.Hosting;

namespace SchoolExpress.WebService
{
    public class RunService : IDisposable
    {
        private static readonly ILog Log = LogManager.GetLogger<RunService>();
        private IDisposable _app;

        public void Start()
        {
            string uri = ConfigurationManager.AppSettings["BaseUri"];
            _app = WebApp.Start<Startup>(uri);
            Log.InfoFormat("Server running in: {0}", uri);
            if (Debugger.IsAttached)
            {
                Process.Start("chrome.exe", uri);
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