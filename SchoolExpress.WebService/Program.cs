using System;
using System.Reflection;
using System.Runtime.InteropServices;
using Common.Logging;
using SchoolExpress.WebService.DbContexts;
using Topshelf;
using Topshelf.Common.Logging;

namespace SchoolExpress.WebService
{
    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger<Program>();

        private static void Main()
        {
            string appId = GetAppId();
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

        private static string GetAppId()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            var attribute = (GuidAttribute) assembly.GetCustomAttributes(typeof(GuidAttribute), true)[0];
            var id = attribute.Value;
            return id;
        }
    }
}