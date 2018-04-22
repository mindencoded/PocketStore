using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/users")]
    public class UsersApiController : CrudApiController<User>
    {
        public UsersApiController(ISchoolExpressUow uow) : base(uow)
        {
        }
    }
}