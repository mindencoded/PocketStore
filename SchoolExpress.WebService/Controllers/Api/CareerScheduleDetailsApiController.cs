using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/careerscheduledetails")]
    public class CareerScheduleDetailsApiController : CrudApiController<CareerScheduleDetail>
    {
        public CareerScheduleDetailsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.careerscheduledetails.get")]
        public override IEnumerable<CareerScheduleDetail> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.careerscheduledetails.get")]
        public override async Task<CareerScheduleDetail> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.careerscheduledetails.put")]
        protected override async Task<HttpResponseMessage> Put(CareerScheduleDetail entity)
        {
            return await base.Put(entity);
        }


        [Authorize(Roles = "api.careerscheduledetails.post")]
        public override async Task<HttpResponseMessage> Post(CareerScheduleDetail entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.careerscheduledetails.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}