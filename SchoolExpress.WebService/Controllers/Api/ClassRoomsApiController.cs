using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("api/classrooms")]
    public class ClassRoomsApiController : BaseApiController<ClassRoom>
    {
        private readonly ISchoolExpressUow _uow;

        public ClassRoomsApiController(ISchoolExpressUow uow) : base(uow)
        {
            _uow = uow;
        }
    }
}