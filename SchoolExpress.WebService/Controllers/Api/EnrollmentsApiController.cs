using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("api/enrollments")]
    public class EnrollmentsApiController : BaseApiController<Enrollment>
    {
        private readonly ISchoolExpressUow _uow;

        public EnrollmentsApiController(ISchoolExpressUow uow) : base(uow)
        {
            _uow = uow;
        }
    }
}