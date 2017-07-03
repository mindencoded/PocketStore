using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers
{
    [RoutePrefix("api/grades")]
    public class GradesApiController : BaseApiController<Grade>
    {
        private readonly ISchoolExpressUow _uow;

        public GradesApiController(ISchoolExpressUow uow) : base(uow)
        {
            _uow = uow;
        }
    }
}