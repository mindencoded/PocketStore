using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/coursescheduledetails")]
    public class CourseScheduleDetailsApiController : CrudApiController<CourseScheduleDetail>
    {
        public CourseScheduleDetailsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "SelectCourseScheduleDetail")]
        public override IEnumerable<CourseScheduleDetail> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "SelectCourseScheduleDetail")]
        public override CourseScheduleDetail Get(int id)
        {
            return base.Get(id);
        }


        [Authorize(Roles = "UpdateCourseScheduleDetail")]
        protected override HttpResponseMessage Put(CourseScheduleDetail entity)
        {
            return base.Put(entity);
        }


        [Authorize(Roles = "InsertCourseScheduleDetail")]
        public override HttpResponseMessage Post(CourseScheduleDetail entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = "DeleteCourseScheduleDetail")]
        public override HttpResponseMessage Delete(int id)
        {
            return base.Delete(id);
        }

    }
}