using System.Web.Http;
using SchoolExpress.Data.Repositories;
using SchoolExpress.Data.Uows;
using SchoolExpress.Domain;
using SchoolExpress.WebService.Models;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("api/audience")]
    public class AudienceController : BaseApiController
    {
        public AudienceController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Route("")]
        [HttpPost]
        public IHttpActionResult Post(AudienceModel audienceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IAudienceRepository audienceRepository = Uow.GetRepository<IAudienceRepository>();
            audienceRepository.Add(audienceModel.Name);
            Uow.Commit();
            Audience audience = audienceRepository.GetByName(audienceModel.Name);
            return Created(Request.RequestUri.AbsoluteUri + "/" + audience.ClientId, audience);
            //return Ok(audience);
        }

        [Route("{id}")]
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            IAudienceRepository audienceRepository = Uow.GetRepository<IAudienceRepository>();
            Audience audience = audienceRepository.GetById(id);
            return Ok(audience);
        }
    }
}