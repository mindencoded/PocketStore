using System.Collections.Generic;
using System.Net.Http;
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
        public override Assignment Get(object id)
        {
            return base.Get(id);
        }


        [Authorize(Roles = "api.assignments.put")]
        protected override HttpResponseMessage Put(Assignment entity)
        {
            return base.Put(entity);
        }


        [Authorize(Roles = "api.assignments.post")]
        public override HttpResponseMessage Post(Assignment entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = "api.assignments.delete")]
        public override HttpResponseMessage Delete(object id)
        {
            return base.Delete(id);
        }
    }
}