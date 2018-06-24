using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("api/careerdetails")]
    public class CareerDetailsApiController : CrudApiController<CareerDetail>
    {
        public CareerDetailsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.careerdetails.get")]
        public override IEnumerable<CareerDetail> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.careerdetails.get")]
        public override async Task<CareerDetail> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.careerdetails.put")]
        protected override async Task<HttpResponseMessage> Put(CareerDetail entity)
        {
            return await base.Put(entity);
        }


        [Authorize(Roles = "api.careerdetails.post")]
        public override async Task<HttpResponseMessage> Post(CareerDetail entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.careerdetails.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}