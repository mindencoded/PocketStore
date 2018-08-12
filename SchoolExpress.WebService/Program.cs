using System;
using Common.Logging;
using Topshelf;
using Topshelf.Common.Logging;

namespace SchoolExpress.WebService
{
    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger("TraceSourceApp");

        private static void Main()
        {
            try
            {
                HostFactory.Run(c =>
                {
                    c.UseCommonLogging();
                    c.Service<RunService>(s =>
                    {
                        s.ConstructUsing(() => new RunService());
                        s.WhenStarted((a) => a.Start());
                        s.WhenStopped((a) => a.Stop());
                    });
                    c.RunAsLocalService();
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex);
            }
        }
    }
}