using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("api/modules")]
    public class ModuleApiController : CrudApiController<Module>
    {
        public ModuleApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.modules.get")]
        public override IEnumerable<Module> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.modules.get")]
        public override async Task<Module> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.modules.put")]
        protected override async Task<HttpResponseMessage> Put(Module entity)
        {
            return await base.Put(entity);
        }

        [Authorize(Roles = "api.modules.post")]
        public override async Task<HttpResponseMessage> Post(Module entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.modules.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}