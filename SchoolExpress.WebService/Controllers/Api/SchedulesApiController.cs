using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/schedules")]
    public class SchedulesApiController : BaseApiController<Schedule>
    {
        public SchedulesApiController(ISchoolExpressUow uow) : base(uow)
        {
        }
    }
}