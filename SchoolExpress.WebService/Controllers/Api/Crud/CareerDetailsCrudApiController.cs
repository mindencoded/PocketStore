using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api.Crud
{
    [RoutePrefix("api/crud/careerdetails")]
    public class CareerDetailsCrudApiController : CrudApiController<CareerDetail>
    {
        public CareerDetailsCrudApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.crud.careerdetails.get")]
        public override IEnumerable<CareerDetail> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.crud.careerdetails.get")]
        public override async Task<CareerDetail> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.crud.careerdetails.put")]
        public override async Task<HttpResponseMessage> Put(CareerDetail entity)
        {
            return await base.Put(entity);
        }


        [Authorize(Roles = "api.crud.careerdetails.post")]
        public override async Task<HttpResponseMessage> Post(CareerDetail entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.crud.careerdetails.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}