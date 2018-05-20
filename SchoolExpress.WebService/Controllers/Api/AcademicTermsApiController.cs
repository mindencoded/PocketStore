using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Data.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("api/academicterms")]
    public class AcademicTermsApiController : CrudApiController<AcademicTerm>
    {
        public AcademicTermsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.academicterms.get")]
        public override IEnumerable<AcademicTerm> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.academicterms.get")]
        public override AcademicTerm Get(object id)
        {
            return base.Get(id);
        }


        [Authorize(Roles = "api.academicterms.put")]
        protected override HttpResponseMessage Put(AcademicTerm entity)
        {
            return base.Put(entity);
        }

        [Authorize(Roles = "api.academicterms.post")]
        public override HttpResponseMessage Post(AcademicTerm entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = "api.academicterms.delete")]
        public override HttpResponseMessage Delete(object id)
        {
            return base.Delete(id);
        }
    }
}