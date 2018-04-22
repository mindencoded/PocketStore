using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/enrollments")]
    public class EnrollmentsApiController : BaseApiController<Enrollment>
    {
        public EnrollmentsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }
    }
}