using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers
{
    [RoutePrefix("api/roles")]
    public class RolesApiController : BaseApiController<Role>
    {
        private readonly ISchoolExpressUow _uow;
        public RolesApiController(ISchoolExpressUow uow) : base(uow)
        {
            _uow = uow;
        }
    }
}