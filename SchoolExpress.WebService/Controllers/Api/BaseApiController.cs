using System.Web.Http;
using Common.Logging;
using Microsoft.AspNet.Identity;
using SchoolExpress.Data.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    public abstract class BaseApiController : ApiController
    {
        protected readonly IUow Uow;
        protected ILog Log;

        protected BaseApiController(IUow uow)
        {
            Uow = uow;
            Log = LogManager.GetLogger(GetType());
        }
    }
}