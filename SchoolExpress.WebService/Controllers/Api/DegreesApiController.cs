using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.Data.Uows;
using SchoolExpress.Domain;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("api/degrees")]
    public class DegreesApiController : CrudApiController<Degree>
    {
        public DegreesApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.degrees.get")]
        public override IEnumerable<Degree> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.degrees.get")]
        public override async Task<Degree> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.degrees.put")]
        protected override async Task<HttpResponseMessage> Put(Degree entity)
        {
            return await base.Put(entity);
        }

        [Authorize(Roles = "api.degrees.post")]
        public override async Task<HttpResponseMessage> Post(Degree entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.degrees.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}