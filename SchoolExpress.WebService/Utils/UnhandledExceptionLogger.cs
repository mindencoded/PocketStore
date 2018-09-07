
using System.Web.Http.ExceptionHandling;
using Common.Logging;

namespace SchoolExpress.WebService.Utils
{
    public class UnhandledExceptionLogger : ExceptionLogger
    {
        private static readonly ILog Logger = LogManager.GetLogger("customTraceSource");

        public override void Log(ExceptionLoggerContext context)
        {
            Logger.Error(context.ExceptionContext.Exception);
        }
    }
}
