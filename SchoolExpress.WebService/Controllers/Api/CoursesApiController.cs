using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/courses")]
    public class CoursesApiController : BaseApiController<Course>
    {
        public CoursesApiController(ISchoolExpressUow uow) : base(uow)
        {
        }
    }
}