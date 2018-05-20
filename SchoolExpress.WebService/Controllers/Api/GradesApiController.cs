using System.Collections.Generic;
using System.Net.Http;
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
        public override Grade Get(object id)
        {
            return base.Get(id);
        }


        [Authorize(Roles = "api.grades.put")]
        protected override HttpResponseMessage Put(Grade entity)
        {
            return base.Put(entity);
        }


        [Authorize(Roles = "api.grades.post")]
        public override HttpResponseMessage Post(Grade entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = "api.grades.delete")]
        public override HttpResponseMessage Delete(object id)
        {
            return base.Delete(id);
        }
    }
}