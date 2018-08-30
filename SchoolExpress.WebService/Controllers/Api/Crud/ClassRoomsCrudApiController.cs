using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.Controllers.Api.Crud
{
    [RoutePrefix("api/crud/classrooms")]
    public class ClassRoomsCrudApiController : CrudApiController<ClassRoom>
    {
        public ClassRoomsCrudApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.crud.classrooms.get")]
        public override QueryResponse<ClassRoom> Get(int page, int pageSize, string orderBy)
        {
            return base.Get(page, pageSize, orderBy);
        }

        [Authorize(Roles = "api.crud.classrooms.get")]
        public override async Task<ClassRoom> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.crud.classrooms.put")]
        public override async Task<HttpResponseMessage> Put(ClassRoom entity)
        {
            return await base.Put(entity);
        }


        [Authorize(Roles = "api.crud.classrooms.post")]
        public override async Task<HttpResponseMessage> Post(ClassRoom entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.crud.classrooms.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}