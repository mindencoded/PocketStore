using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using SchoolExpress.Domain;
using SchoolExpress.Data.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/courseschedules")]
    public class CourseSchedulesApiController : CrudApiController<CourseSchedule>
    {
        public CourseSchedulesApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.courseschedules.get")]
        public override IEnumerable<CourseSchedule> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.courseschedules.get")]
        public override async Task<CourseSchedule> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.courseschedules.put")]
        protected override async Task<HttpResponseMessage> Put(CourseSchedule entity)
        {
            return await base.Put(entity);
        }


        [Authorize(Roles = "api.courseschedules.post")]
        public override async Task<HttpResponseMessage> Post(CourseSchedule entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.courseschedules.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}