using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("api/periods")]
    public class PeriodApiController : CrudApiController<Period>
    {
        public PeriodApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.periods.get")]
        public override IEnumerable<Period> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.periods.get")]
        public override async Task<Period> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.periods.put")]
        protected override async Task<HttpResponseMessage> Put(Period entity)
        {
            return await base.Put(entity);
        }

        [Authorize(Roles = "api.periods.post")]
        public override async Task<HttpResponseMessage> Post(Period entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.periods.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}