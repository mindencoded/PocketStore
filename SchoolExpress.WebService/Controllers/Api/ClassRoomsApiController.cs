using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/classrooms")]
    public class ClassRoomsApiController : BaseApiController<ClassRoom>
    {
        public ClassRoomsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }
    }
}