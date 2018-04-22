using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [RoutePrefix("api/academicterms")]
    public class AcademicTermsApiController : CrudApiController<AcademicTerm>
    {
        public AcademicTermsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "SelectAcademicTerm")]
        public override IEnumerable<AcademicTerm> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "SelectAcademicTerm")]
        public override AcademicTerm Get(int id)
        {
            return base.Get(id);
        }


        [Authorize(Roles = "UpdateAcademicTerm")]
        protected override HttpResponseMessage Put(AcademicTerm entity)
        {
            return base.Put(entity);
        }


        [Authorize(Roles = "InsertAcademicTerm")]
        public override HttpResponseMessage Post(AcademicTerm entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = "DeleteAcademicTerm")]
        public override HttpResponseMessage Delete(int id)
        {
            return base.Delete(id);
        }

    }
}