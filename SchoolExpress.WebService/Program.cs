﻿using System;
using Common.Logging;
using Topshelf;
using Topshelf.Common.Logging;

namespace SchoolExpress.WebService
{
    public class Program
    {
        private static readonly ILog Logger = LogManager.GetLogger("customTraceSource");

        private static void Main()
        {
            try
            {
                HostFactory.Run(c =>
                {
                    c.UseCommonLogging();
                    c.Service<WorkerRole>(s =>
                    {
                        s.ConstructUsing(() => new WorkerRole());
                        s.WhenStarted(a => a.OnStart());
                        s.WhenStopped(a => a.OnStop());
                    });
                    c.RunAsLocalService();
                });
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
            }
        }
    }
}