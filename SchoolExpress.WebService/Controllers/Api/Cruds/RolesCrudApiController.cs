using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api.Cruds
{
    [RoutePrefix("api/cruds/roles")]
    public class RolesCrudApiController: CrudApiController<Role>
    {
        public RolesCrudApiController(ISchoolExpressUow uow) : base(uow)
        {
        }
        
        [Authorize(Roles = "api.cruds.roles.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy)
        {
            return base.Get(page, pageSize, orderBy);
        }

        [Authorize(Roles = "api.cruds.roles.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy, string where)
        {
            return base.Get(page, pageSize, orderBy, where);
        }
        
        [Authorize(Roles = "api.cruds.roles.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy, string where, string select)
        {
            return base.Get(page, pageSize, orderBy, where, select);
        }

        [Authorize(Roles = "api.cruds.roles.get")]
        public override async Task<HttpResponseMessage> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.cruds.roles.put")]
        public override async Task<HttpResponseMessage> Put(Role entity)
        {
            return await base.Put(entity);
        }


        [Authorize(Roles = "api.cruds.roles.post")]
        public override async Task<HttpResponseMessage> Post(Role entity)
        {
            return await base.Post(entity);
        }
        
        [Authorize(Roles = "api.cruds.roles.patch")]
        public override async Task<HttpResponseMessage> Patch([FromBody] string json)
        {
            return await base.Patch(json);
        }

        [Authorize(Roles = "api.cruds.roles.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}