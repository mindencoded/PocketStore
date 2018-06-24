using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("api/campus")]
    public class CampusApiController : CrudApiController<Campus>
    {
        public CampusApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.campus.get")]
        public override IEnumerable<Campus> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.campus.get")]
        public override async Task<Campus> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.campus.put")]
        protected override async Task<HttpResponseMessage> Put(Campus entity)
        {
            return await base.Put(entity);
        }

        [Authorize(Roles = "api.campus.post")]
        public override async Task<HttpResponseMessage> Post(Campus entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.campus.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}