using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/careerschedules")]
    public class CareerSchedulesApiController : CrudApiController<CareerSchedule>
    {
        public CareerSchedulesApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.careerschedules.get")]
        public override IEnumerable<CareerSchedule> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.careerschedules.get")]
        public override async Task<CareerSchedule> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.careerschedules.put")]
        protected override async Task<HttpResponseMessage> Put(CareerSchedule entity)
        {
            return await base.Put(entity);
        }


        [Authorize(Roles = "api.careerschedules.post")]
        public override async Task<HttpResponseMessage> Post(CareerSchedule entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.careerschedules.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}