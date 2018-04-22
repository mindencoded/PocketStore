using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/persons")]
    public class PersonsApiController : BaseApiController<Person>
    {
        public PersonsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }
    }
}