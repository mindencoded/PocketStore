using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers
{
    [RoutePrefix("api/academicterms")]
    public class AcademicTermsApiController : BaseApiController<AcademicTerm>
    {
        private readonly ISchoolExpressUow _uow;
        public AcademicTermsApiController(ISchoolExpressUow uow) : base(uow)
        {
            _uow = uow;
        }
    }
}