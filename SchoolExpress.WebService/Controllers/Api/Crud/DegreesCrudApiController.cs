using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api.Crud
{
    [RoutePrefix("api/crud/degrees")]
    public class DegreesCrudApiController : CrudApiController<Degree>
    {
        public DegreesCrudApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.crud.degrees.get")]
        public override IEnumerable<Degree> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.crud.degrees.get")]
        public override async Task<Degree> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.crud.degrees.put")]
        public override async Task<HttpResponseMessage> Put(Degree entity)
        {
            return await base.Put(entity);
        }

        [Authorize(Roles = "api.crud.degrees.post")]
        public override async Task<HttpResponseMessage> Post(Degree entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.crud.degrees.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}