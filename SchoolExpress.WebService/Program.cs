using System;
using Common.Logging;
using SchoolExpress.WebService.Utils;
using Topshelf;
using Topshelf.Common.Logging;

namespace SchoolExpress.WebService {
    public class Program {
        private static readonly ILog Log = LogManager.GetLogger<Program> ();

        static void Main () {
            try
            {
                if (Environment.UserInteractive)
                {
                    LogManager.Adapter = new ColoredConsoleOutLoggerFactoryAdapter();
                }

                HostFactory.Run (c => {
                    c.UseCommonLogging();
                    c.Service<RunService> (s => {
                        s.ConstructUsing (() => new RunService ());
                        s.WhenStarted ((service) => service.Start ());
                        s.WhenStopped ((service) => service.Stop ());
                    });
                    c.RunAsLocalService();
                });
            } catch (Exception ex) {
                Log.Error (ex);
            }
        }
    }
}