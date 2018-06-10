using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Data.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/assignments")]
    public class AssignmentsApiController : CrudApiController<Assignment>
    {
        public AssignmentsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }


        [Authorize(Roles = "api.assignments.get")]
        public override IEnumerable<Assignment> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.assignments.get")]
        public override async Task<Assignment> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.assignments.put")]
        protected override async Task<HttpResponseMessage> Put(Assignment entity)
        {
            return await base.Put(entity);
        }


        [Authorize(Roles = "api.assignments.post")]
        public override async Task<HttpResponseMessage> Post(Assignment entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.assignments.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}