using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api.Crud
{
    [RoutePrefix("api/crud/students")]
    public class StudentsCrudApiController : CrudApiController<Student>
    {
        public StudentsCrudApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.crud.students.get")]
        public override IEnumerable<Student> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.crud.students.get")]
        public override async Task<Student> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.crud.students.put")]
        protected override async Task<HttpResponseMessage> Put(Student entity)
        {
            return await base.Put(entity);
        }

        [Authorize(Roles = "api.crud.students.post")]
        public override async Task<HttpResponseMessage> Post(Student entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.crud.students.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}