using System.Runtime.Remoting.Messaging;
using Microsoft.Owin;

namespace SchoolExpress.WebService.Utils
{
    public class HttpContext
    {
        private const string OwinContextKey = "owin.IOwinContext";

        public static IOwinContext Current
        {
            get { return (IOwinContext) CallContext.LogicalGetData(OwinContextKey); }
        }

        public static void Set(IOwinContext context)
        {
            CallContext.LogicalSetData(OwinContextKey, context);
        }

        public static void Remove(IOwinContext context)
        {
            CallContext.FreeNamedDataSlot(OwinContextKey);
        }
    }
}