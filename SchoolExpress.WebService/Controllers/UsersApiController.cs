using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers
{
    [RoutePrefix("api/users")]
    public class UsersApiController : BaseApiController<User>
    {
        private readonly ISchoolExpressUow _uow;
        public UsersApiController(ISchoolExpressUow uow) : base(uow)
        {
            _uow = uow;
        }
    }
}