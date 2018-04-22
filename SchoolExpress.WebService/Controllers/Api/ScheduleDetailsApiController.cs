using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/scheduledetails")]
    public class ScheduleDetailsApiController : BaseApiController<ScheduleDetail>
    {
        public ScheduleDetailsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }
    }
}