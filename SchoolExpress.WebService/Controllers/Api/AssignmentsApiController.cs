using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/assignments")]
    public class AssignmentsApiController : BaseApiController<Assignment>
    {
        public AssignmentsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }
    }
}