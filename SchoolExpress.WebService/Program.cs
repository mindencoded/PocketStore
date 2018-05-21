using System;
using System.Diagnostics;
using Common.Logging;
using SchoolExpress.WebService.Utils;
using Topshelf;
using Topshelf.Common.Logging;
using Topshelf.HostConfigurators;

namespace SchoolExpress.WebService
{
    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger<Program>();

        private static void Main()
        {
            try
            {
                HostFactory.Run(c =>
                {
                    UseCommonLogging(c);
                    c.Service<RunService>(s =>
                    {
                        s.ConstructUsing(() => new RunService());
                        s.WhenStarted((service) => service.Start());
                        s.WhenStopped((service) => service.Stop());
                    });
                    c.RunAsLocalService();
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }

        private static void UseCommonLogging(HostConfigurator hostConfigurator)
        {
            if (Environment.UserInteractive && Debugger.IsAttached)
            {
                hostConfigurator.UseCommonLogging();
                LogManager.Adapter = new ColoredConsoleOutLoggerFactoryAdapter();
            }
        }
    }
}