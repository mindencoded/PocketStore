﻿using System;
using System.Configuration;
using Common.Logging;
using Microsoft.Owin.Hosting;
using Microsoft.WindowsAzure.ServiceRuntime;
using Topshelf;

namespace SchoolExpress.WebService
{
    public class WorkerRole : RoleEntryPoint, ServiceControl
    {
        private static readonly ILog Log = LogManager.GetLogger("TraceSourceApp");
        private IDisposable _app;

        public override bool OnStart()
        {
            string baseUri = ConfigurationManager.AppSettings["BaseUri"];
            try
            {

                RoleInstanceEndpoint endpoint = RoleEnvironment.CurrentRoleInstance.InstanceEndpoints["ApiEndpoint"];
                if (endpoint != null)
                {
                    baseUri = string.Format("{0}://{1}", endpoint.Protocol, endpoint.IPEndpoint);
                }
            }
            catch (InvalidOperationException)
            { 
            }

            _app = WebApp.Start<Startup>(new StartOptions(baseUri));

            Log.InfoFormat("Server running in: {0}", baseUri);
            return base.OnStart();
        }

        public override void OnStop()
        {
            if (_app != null)
            {
                _app.Dispose();
            }
            base.OnStop();
        }

        public bool Start(HostControl hostControl)
        {
            return OnStart();
        }

        public bool Stop(HostControl hostControl)
        {
            OnStop();
            return true;
        }
    }
}