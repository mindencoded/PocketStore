using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers
{
    [RoutePrefix("api/persons")]
    public class PersonsApiController : BaseApiController<Person>
    {
        private readonly ISchoolExpressUow _uow;
        public PersonsApiController(ISchoolExpressUow uow) : base(uow)
        {
            uow = _uow;
        }
    }
}