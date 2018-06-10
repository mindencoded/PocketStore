using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Data.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/grades")]
    public class GradesApiController : CrudApiController<Grade>
    {
        public GradesApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.grades.get")]
        public override IEnumerable<Grade> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.grades.get")]
        public override async Task<Grade> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.grades.put")]
        protected override async Task<HttpResponseMessage> Put(Grade entity)
        {
            return await base.Put(entity);
        }


        [Authorize(Roles = "api.grades.post")]
        public override async Task<HttpResponseMessage> Post(Grade entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.grades.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}