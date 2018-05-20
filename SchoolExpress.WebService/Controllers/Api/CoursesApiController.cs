using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Data.Uows;
using SchoolExpress.WebService.Filters;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("api/courses")]
    public class CoursesApiController : CrudApiController<Course>
    {
        public CoursesApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.courses.get")]
        public override IEnumerable<Course> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.courses.get")]
        public override Course Get(object id)
        {
            return base.Get(id);
        }


        [Authorize(Roles = "api.courses.put")]
        protected override HttpResponseMessage Put(Course entity)
        {
            return base.Put(entity);
        }


        [Authorize(Roles = "api.courses.post")]
        public override HttpResponseMessage Post(Course entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = "api.courses.delete")]
        public override HttpResponseMessage Delete(object id)
        {
            return base.Delete(id);
        }
    }
}