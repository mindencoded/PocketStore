using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Repositories;
using SchoolExpress.Infrastructure.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/enrollmentdetails")]
    public class EnrollmentDetailsApiController : CrudApiController<EnrollmentDetail>
    {
        public EnrollmentDetailsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "SelectEnrollmentDetail")]
        [Route("{assignment:int}/{enrollmentId:int}")]
        public EnrollmentDetail Get(int assignment, int enrollmentId)
        {
            var enrollmentDetail =
                Uow.GetRepository<IEnrollmentDetailRepository>().GetAll()
                    .FirstOrDefault(x => x.AssignmentId == assignment && x.EnrollmentId == enrollmentId);
            if (enrollmentDetail != null)
                return enrollmentDetail;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        [Authorize(Roles = "DeleteEnrollmentDetail")]
        [Route("{assignment:int}/{enrollmentId:int}")]
        public HttpResponseMessage Delete(int assignment, int enrollmentId)
        {
            var enrollmentDetail =
                Uow.GetRepository<IEnrollmentDetailRepository>().GetAll()
                    .FirstOrDefault(x => x.AssignmentId == assignment && x.EnrollmentId == enrollmentId);
            if (enrollmentDetail != null)
            {
                Uow.GetRepository<IEnrollmentDetailRepository>().Delete(enrollmentDetail);
                Uow.Commit();
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }

            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        [Authorize(Roles = "SelectEnrollmentDetail")]
        public override IEnumerable<EnrollmentDetail> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "SelectEnrollmentDetail")]
        public override EnrollmentDetail Get(int id)
        {
            return base.Get(id);
        }


        [Authorize(Roles = "UpdateEnrollmentDetail")]
        protected override HttpResponseMessage Put(EnrollmentDetail entity)
        {
            return base.Put(entity);
        }


        [Authorize(Roles = "InsertEnrollmentDetail")]
        public override HttpResponseMessage Post(EnrollmentDetail entity)
        {
            return base.Post(entity);
        }

        [Authorize(Roles = "DeleteEnrollmentDetail")]
        public override HttpResponseMessage Delete(int id)
        {
            return base.Delete(id);
        }
    }
}