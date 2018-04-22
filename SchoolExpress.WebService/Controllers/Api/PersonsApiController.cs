using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Data.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/persons")]
    public class PersonsApiController : CrudApiController<Person>
    {
        public PersonsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "SelectPerson")]
        public override IEnumerable<Person> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "SelectPerson")]
        public override Person Get(int id)
        {
            return base.Get(id);
        }


        [Authorize(Roles = "UpdatePerson")]
        protected override HttpResponseMessage Put(Person entity)
        {
            return base.Put(entity);
        }


        [Authorize(Roles = "InsertPerson")]
        public override HttpResponseMessage Post(Person entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = "DeletePerson")]
        public override HttpResponseMessage Delete(int id)
        {
            return base.Delete(id);
        }
    }
}