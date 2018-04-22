using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/users")]
    public class UsersApiController : BaseApiController<User>
    {
        public UsersApiController(ISchoolExpressUow uow) : base(uow)
        {
        }
    }
}