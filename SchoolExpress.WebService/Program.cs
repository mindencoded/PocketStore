using System;
using Common.Logging;
using Topshelf;

namespace SchoolExpress.WebService
{
    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger<Program>();

        static int Main()
        {
            try
            {
                return (int) HostFactory.Run(c =>
                {
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