using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/grades")]
    public class GradesApiController : BaseApiController<Grade>
    {
        public GradesApiController(ISchoolExpressUow uow) : base(uow)
        {
        }
    }
}