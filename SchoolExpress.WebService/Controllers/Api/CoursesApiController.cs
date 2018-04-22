using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Data.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/courses")]
    public class CoursesApiController : CrudApiController<Course>
    {
        public CoursesApiController(ISchoolExpressUow uow) : base(uow)
        {
        }


        [Authorize(Roles = "SelectCourse")]
        public override IEnumerable<Course> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "SelectCourse")]
        public override Course Get(int id)
        {
            return base.Get(id);
        }


        [Authorize(Roles = "UpdateCourse")]
        protected override HttpResponseMessage Put(Course entity)
        {
            return base.Put(entity);
        }


        [Authorize(Roles = "InsertCourse")]
        public override HttpResponseMessage Post(Course entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = "DeleteCourse")]
        public override HttpResponseMessage Delete(int id)
        {
            return base.Delete(id);
        }
    }
}