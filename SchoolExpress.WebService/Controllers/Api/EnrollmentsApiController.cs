using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/enrollments")]
    public class EnrollmentsApiController : CrudApiController<Enrollment>
    {
        public EnrollmentsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.enrollments.get")]
        public override IEnumerable<Enrollment> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.enrollments.get")]
        public override async Task<Enrollment> Get(object id)
        {
            return await base.Get(id);
        }


        [Authorize(Roles = "api.enrollments.put")]
        protected override async Task<HttpResponseMessage> Put(Enrollment entity)
        {
            return await base.Put(entity);
        }


        [Authorize(Roles = "api.enrollments.put")]
        public override async Task<HttpResponseMessage> Post(Enrollment entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.enrollments.delete")]
        public override async Task<HttpResponseMessage> Delete(object id)
        {
            return await base.Delete(id);
        }
    }
}