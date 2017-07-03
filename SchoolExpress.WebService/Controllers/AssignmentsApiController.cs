using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers
{
    [RoutePrefix("api/assignments")]
    public class AssignmentsApiController : BaseApiController<Assignment>
    {
        private readonly ISchoolExpressUow _uow;

        public AssignmentsApiController(ISchoolExpressUow uow) : base(uow)
        {
            _uow = uow;
        }
    }
}