using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Data.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/coursescheduledetails")]
    public class CourseScheduleDetailsApiController : CrudApiController<CourseScheduleDetail>
    {
        public CourseScheduleDetailsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.coursescheduledetails.get")]
        public override IEnumerable<CourseScheduleDetail> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.coursescheduledetails.get")]
        public override async Task<CourseScheduleDetail> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.coursescheduledetails.put")]
        protected override async Task<HttpResponseMessage> Put(CourseScheduleDetail entity)
        {
            return await base.Put(entity);
        }


        [Authorize(Roles = "api.coursescheduledetails.post")]
        public override async Task<HttpResponseMessage> Post(CourseScheduleDetail entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.coursescheduledetails.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}