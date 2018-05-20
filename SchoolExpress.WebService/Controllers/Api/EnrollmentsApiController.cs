using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Data.Uows;

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
        public override Enrollment Get(object id)
        {
            return base.Get(id);
        }


        [Authorize(Roles = "api.enrollments.put")]
        protected override HttpResponseMessage Put(Enrollment entity)
        {
            return base.Put(entity);
        }


        [Authorize(Roles = "api.enrollments.put")]
        public override HttpResponseMessage Post(Enrollment entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = "api.enrollments.delete")]
        public override HttpResponseMessage Delete(object id)
        {
            return base.Delete(id);
        }
    }
}