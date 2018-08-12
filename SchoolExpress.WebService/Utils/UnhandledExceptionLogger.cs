
using System.Web.Http.ExceptionHandling;
using Common.Logging;

namespace SchoolExpress.WebService.Utils
{
    public class UnhandledExceptionLogger : ExceptionLogger
    {
        private static ILog _log = LogManager.GetLogger("TraceSourceApp");

        public override void Log(ExceptionLoggerContext context)
        {         
           _log.Error(context.ExceptionContext.Exception);
        }
    }
}
