using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers
{
    [RoutePrefix("api/scheduledetails")]
    public class ScheduleDetailsApiController : BaseApiController<ScheduleDetail>
    {
        private readonly ISchoolExpressUow _uow;
        public ScheduleDetailsApiController(ISchoolExpressUow uow) : base(uow)
        {
            _uow = uow;
        }
    }
}