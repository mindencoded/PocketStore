using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.Controllers.Api.Cruds
{
    [RoutePrefix("api/cruds/students")]
    public class StudentsCrudApiController : CrudApiController<Student>
    {
        public StudentsCrudApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.cruds.students.get")]
        public override Task<QueryResponse> Get(int page, int pageSize, string orderBy)
        {
            return base.Get(page, pageSize, orderBy);
        }

        [Authorize(Roles = "api.cruds.students.get")]
        public override Task<QueryResponse> Get(int page, int pageSize, string orderBy, string where)
        {
            return base.Get(page, pageSize, orderBy, where);
        }

        [Authorize(Roles = "api.cruds.students.get")]
        public override async Task<HttpResponseMessage> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.cruds.students.put")]
        public override async Task<HttpResponseMessage> Put(Student entity)
        {
            return await base.Put(entity);
        }

        [Authorize(Roles = "api.cruds.students.post")]
        public override async Task<HttpResponseMessage> Post(Student entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.cruds.students.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}