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

        [Authorize(Roles = "SelectGrade")]
        public override IEnumerable<Grade> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "SelectGrade")]
        public override Grade Get(int id)
        {
            return base.Get(id);
        }


        [Authorize(Roles = "UpdateGrade")]
        protected override HttpResponseMessage Put(Grade entity)
        {
            return base.Put(entity);
        }


        [Authorize(Roles = "InsertGrade")]
        public override HttpResponseMessage Post(Grade entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = "DeleteGrade")]
        public override HttpResponseMessage Delete(int id)
        {
            return base.Delete(id);
        }
    }
}