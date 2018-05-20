using System.Threading.Tasks;
using Microsoft.Owin;

namespace SchoolExpress.WebService.Utils
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
                HttpContext.Set(context);
                await Next.Invoke(context);
            }
            finally
            {
                HttpContext.Remove(context);
            }
        }
    }
}