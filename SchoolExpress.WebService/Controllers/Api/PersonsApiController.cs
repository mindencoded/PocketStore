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

        [Authorize(Roles = "api.persons.get")]
        public override IEnumerable<Person> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.persons.get")]
        public override Person Get(object id)
        {
            return base.Get(id);
        }


        [Authorize(Roles = "api.persons.put")]
        protected override HttpResponseMessage Put(Person entity)
        {
            return base.Put(entity);
        }


        [Authorize(Roles = "api.persons.post")]
        public override HttpResponseMessage Post(Person entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = "api.persons.delete")]
        public override HttpResponseMessage Delete(object id)
        {
            return base.Delete(id);
        }
    }
}