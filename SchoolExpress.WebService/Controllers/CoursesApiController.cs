using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers
{
    [RoutePrefix("api/courses")]
    public class CoursesApiController : BaseApiController<Course>
    {
        private readonly ISchoolExpressUow _uow;
        public CoursesApiController(ISchoolExpressUow uow) : base(uow)
        {
            _uow = uow;
        }
    }
}