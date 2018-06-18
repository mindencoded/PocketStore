using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.Data.Uows;
using SchoolExpress.Domain;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("api/speakers")]
    public class SpeakerApiController : CrudApiController<Speaker>
    {
        public SpeakerApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.speakers.get")]
        public override IEnumerable<Speaker> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.speakers.get")]
        public override async Task<Speaker> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.speakers.put")]
        protected override async Task<HttpResponseMessage> Put(Speaker entity)
        {
            return await base.Put(entity);
        }

        [Authorize(Roles = "api.speakers.post")]
        public override async Task<HttpResponseMessage> Post(Speaker entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.speakers.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}