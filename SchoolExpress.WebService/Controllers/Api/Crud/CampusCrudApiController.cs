using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api.Crud
{
    [RoutePrefix("api/crud/campus")]
    public class CampusCrudApiController : CrudApiController<Campus>
    {
        public CampusCrudApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.crud.campus.get")]
        public override IEnumerable<Campus> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.crud.campus.get")]
        public override async Task<Campus> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.crud.campus.put")]
        protected override async Task<HttpResponseMessage> Put(Campus entity)
        {
            return await base.Put(entity);
        }

        [Authorize(Roles = "api.crud.campus.post")]
        public override async Task<HttpResponseMessage> Post(Campus entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.crud.campus.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}