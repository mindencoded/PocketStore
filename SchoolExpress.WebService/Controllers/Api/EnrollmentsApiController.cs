using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/enrollments")]
    public class EnrollmentsApiController : CrudApiController<Enrollment>
    {
        public EnrollmentsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "SelectEnrollment")]
        public override IEnumerable<Enrollment> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "SelectEnrollment")]
        public override Enrollment Get(int id)
        {
            return base.Get(id);
        }


        [Authorize(Roles = "UpdateEnrollment")]
        protected override HttpResponseMessage Put(Enrollment entity)
        {
            return base.Put(entity);
        }


        [Authorize(Roles = "InsertEnrollment")]
        public override HttpResponseMessage Post(Enrollment entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = "DeleteEnrollment")]
        public override HttpResponseMessage Delete(int id)
        {
            return base.Delete(id);
        }
    }
}