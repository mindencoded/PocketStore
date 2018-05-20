using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
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
        public override CourseSchedule Get(object id)
        {
            return base.Get(id);
        }


        [Authorize(Roles = "api.courseschedules.put")]
        protected override HttpResponseMessage Put(CourseSchedule entity)
        {
            return base.Put(entity);
        }


        [Authorize(Roles = "api.courseschedules.post")]
        public override HttpResponseMessage Post(CourseSchedule entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = "api.courseschedules.delete")]
        public override HttpResponseMessage Delete(object id)
        {
            return base.Delete(id);
        }
    }
}