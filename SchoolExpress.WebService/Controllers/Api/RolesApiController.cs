using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/roles")]
    public class RolesApiController : BaseApiController<Role>
    {
        public RolesApiController(ISchoolExpressUow uow) : base(uow)
        {
        }
    }
}