using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api.Crud
{
    [RoutePrefix("api/crud/courses")]
    public class CoursesCrudApiController : CrudApiController<Course>
    {
        public CoursesCrudApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.crud.courses.get")]
        public override IEnumerable<Course> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.crud.courses.get")]
        public override async Task<Course> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.crud.courses.put")]
        public override async Task<HttpResponseMessage> Put(Course entity)
        {
            return await base.Put(entity);
        }


        [Authorize(Roles = "api.crud.courses.post")]
        public override async Task<HttpResponseMessage> Post(Course entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.crud.courses.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}