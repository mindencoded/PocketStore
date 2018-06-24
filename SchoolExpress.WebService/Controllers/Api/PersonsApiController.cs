using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;

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
        public override async Task<Person> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.persons.put")]
        protected override async Task<HttpResponseMessage> Put(Person entity)
        {
            return await base.Put(entity);
        }


        [Authorize(Roles = "api.persons.post")]
        public override async Task<HttpResponseMessage> Post(Person entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.persons.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}