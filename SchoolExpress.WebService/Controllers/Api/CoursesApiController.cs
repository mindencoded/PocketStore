using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;

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
        public override async Task<Course> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.courses.put")]
        protected override async Task<HttpResponseMessage> Put(Course entity)
        {
            return await base.Put(entity);
        }


        [Authorize(Roles = "api.courses.post")]
        public override async Task<HttpResponseMessage> Post(Course entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.courses.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}