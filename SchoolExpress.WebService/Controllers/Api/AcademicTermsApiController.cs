using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
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
        public override async Task<AcademicTerm> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.academicterms.put")]
        protected override async Task<HttpResponseMessage> Put(AcademicTerm entity)
        {
            return await base.Put(entity);
        }

        [Authorize(Roles = "api.academicterms.post")]
        public override async Task<HttpResponseMessage> Post(AcademicTerm entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.academicterms.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}