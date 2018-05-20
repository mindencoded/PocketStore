using System.Collections.Generic;
using System.Net.Http;
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
        public override CourseScheduleDetail Get(object id)
        {
            return base.Get(id);
        }


        [Authorize(Roles = "api.coursescheduledetails.put")]
        protected override HttpResponseMessage Put(CourseScheduleDetail entity)
        {
            return base.Put(entity);
        }


        [Authorize(Roles = "api.coursescheduledetails.post")]
        public override HttpResponseMessage Post(CourseScheduleDetail entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = "api.coursescheduledetails.delete")]
        public override HttpResponseMessage Delete(object id)
        {
            return base.Delete(id);
        }
    }
}