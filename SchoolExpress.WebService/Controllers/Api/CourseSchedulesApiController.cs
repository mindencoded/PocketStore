using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/courseschedules")]
    public class CourseSchedulesApiController : CrudApiController<CourseSchedule>
    {
        public CourseSchedulesApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "SelectCourseSchedule")]
        public override IEnumerable<CourseSchedule> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "SelectCourseSchedule")]
        public override CourseSchedule Get(int id)
        {
            return base.Get(id);
        }


        [Authorize(Roles = "UpdateCourseSchedule")]
        protected override HttpResponseMessage Put(CourseSchedule entity)
        {
            return base.Put(entity);
        }


        [Authorize(Roles = "InsertCourseSchedule")]
        public override HttpResponseMessage Post(CourseSchedule entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = "DeleteCourseSchedule")]
        public override HttpResponseMessage Delete(int id)
        {
            return base.Delete(id);
        }


    }
}