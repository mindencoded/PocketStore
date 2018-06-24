using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("api/classrooms")]
    public class ClassRoomsApiController : CrudApiController<ClassRoom>
    {
        public ClassRoomsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }


        [Authorize(Roles = "api.classrooms.get")]
        public override IEnumerable<ClassRoom> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.classrooms.get")]
        public override async Task<ClassRoom> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.classrooms.put")]
        protected override async Task<HttpResponseMessage> Put(ClassRoom entity)
        {
            return await base.Put(entity);
        }


        [Authorize(Roles = "api.classrooms.post")]
        public override async Task<HttpResponseMessage> Post(ClassRoom entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.classrooms.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}