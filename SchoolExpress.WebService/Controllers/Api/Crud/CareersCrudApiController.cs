using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.Controllers.Api.Crud
{
    [RoutePrefix("api/crud/careers")]
    public class CareersCrudApiController : CrudApiController<Career>
    {
        public CareersCrudApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.crud.careers.get")]
        public override QueryResponse<Career> Get(int page, int pageSize, string orderBy)
        {
            return base.Get(page, pageSize, orderBy);
        }

        [Authorize(Roles = "api.crud.careers.get")]
        public override async Task<Career> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.crud.careers.put")]
        public override async Task<HttpResponseMessage> Put(Career entity)
        {
            return await base.Put(entity);
        }

        [Authorize(Roles = "api.crud.careers.post")]
        public override async Task<HttpResponseMessage> Post(Career entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.crud.careers.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}