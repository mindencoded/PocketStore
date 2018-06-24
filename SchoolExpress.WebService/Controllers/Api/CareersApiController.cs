using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("api/careers")]
    public class CareersApiController : CrudApiController<Career>
    {
        public CareersApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.careers.get")]
        public override IEnumerable<Career> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.careers.get")]
        public override async Task<Career> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.careers.put")]
        protected override async Task<HttpResponseMessage> Put(Career entity)
        {
            return await base.Put(entity);
        }

        [Authorize(Roles = "api.careers.post")]
        public override async Task<HttpResponseMessage> Post(Career entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.careers.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}