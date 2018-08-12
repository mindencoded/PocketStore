using System.Web.Http;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    public abstract class BaseApiController : ApiController
    {
        protected readonly IUow Uow;

        protected BaseApiController(IUow uow)
        {
            Uow = uow;
        }
    }
}