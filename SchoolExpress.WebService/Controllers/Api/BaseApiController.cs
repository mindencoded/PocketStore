using System.Web.Http;
using Common.Logging;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    public abstract class BaseApiController : ApiController
    {
        protected readonly IUow Uow;
        protected readonly ILog Log;

        protected BaseApiController(IUow uow)
        {
            Uow = uow;
            Log = LogManager.GetLogger(GetType());
        }
    }
}