using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.Controllers.Api.Crud
{
    [Authorize]
    [RoutePrefix("api/crud/enrollments")]
    public class EnrollmentsCrudApiController : CrudApiController<Enrollment>
    {
        public EnrollmentsCrudApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.crud.enrollments.get")]
        public override QueryResponse<Enrollment> Get(int page, int pageSize, string orderBy)
        {
            return base.Get(page, pageSize, orderBy);
        }

        [Authorize(Roles = "api.crud.enrollments.get")]
        public override async Task<Enrollment> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.crud.enrollments.put")]
        public override async Task<HttpResponseMessage> Put(Enrollment entity)
        {
            return await base.Put(entity);
        }


        [Authorize(Roles = "api.crud.enrollments.put")]
        public override async Task<HttpResponseMessage> Post(Enrollment entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.crud.enrollments.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}