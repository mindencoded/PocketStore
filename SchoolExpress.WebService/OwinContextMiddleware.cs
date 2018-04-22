
using System.Threading.Tasks;
using Microsoft.Owin;

namespace SchoolExpress.WebService
{
    public class OwinContextMiddleware : OwinMiddleware
    {
        public OwinContextMiddleware(OwinMiddleware next) : base(next)
        {
        }

        public override async Task Invoke(IOwinContext context)
        {
            try
            {
                OwinCallContext.Set(context);
                await Next.Invoke(context);
            }
            finally
            {
                OwinCallContext.Remove(context);
            }
        }
    }

}
