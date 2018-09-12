using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.Controllers.Api.Cruds
{
    [RoutePrefix("api/cruds/periods")]
    public class PeriodsCrudApiController : CrudApiController<Period>
    {
        public PeriodsCrudApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.cruds.periods.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy)
        {
            return base.Get(page, pageSize, orderBy);
        }

        [Authorize(Roles = "api.cruds.periods.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy, string where)
        {
            return base.Get(page, pageSize, orderBy, where);
        }
        
        [Authorize(Roles = "api.cruds.periods.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy, string where, string select)
        {
            return base.Get(page, pageSize, orderBy, where, select);
        }

        [Authorize(Roles = "api.cruds.periods.get")]
        public override async Task<HttpResponseMessage> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.cruds.periods.put")]
        public override async Task<HttpResponseMessage> Put(Period entity)
        {
            return await base.Put(entity);
        }

        [Authorize(Roles = "api.cruds.periods.post")]
        public override async Task<HttpResponseMessage> Post(Period entity)
        {
            return await base.Post(entity);
        }
        
        [Authorize(Roles = "api.cruds.periods.patch")]
        public override async Task<HttpResponseMessage> Patch([FromBody] string json)
        {
            return await base.Patch(json);
        }  

        [Authorize(Roles = "api.cruds.periods.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}