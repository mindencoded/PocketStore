using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/academicterms")]
    public class AcademicTermsApiController : BaseApiController<AcademicTerm>
    {
        public AcademicTermsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }
    }
}