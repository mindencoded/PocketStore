using System;
using Common.Logging;
using Topshelf;
using Topshelf.Common.Logging;

namespace SchoolExpress.WebService
{
    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger<Program>();

        static void Main()
        {
            try
            {
                HostFactory.Run(c =>
                {
                    c.UseCommonLogging();
                    c.RunAsLocalService();
                    c.Service<OwinService>(s =>
                    {
                        s.ConstructUsing(() => new OwinService());
                        s.WhenStarted((service) => service.Start());
                        s.WhenStopped((service) => service.Stop());
                    });
                });
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                throw;
            }
        }
    }
}