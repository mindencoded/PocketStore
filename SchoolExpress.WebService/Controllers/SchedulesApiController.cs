using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers
{
    [RoutePrefix("api/schedules")]
    public class SchedulesApiController : BaseApiController<Schedule>
    {
        private readonly ISchoolExpressUow _uow;

        public SchedulesApiController(ISchoolExpressUow uow) : base(uow)
        {
            _uow = uow;
        }
    }
}