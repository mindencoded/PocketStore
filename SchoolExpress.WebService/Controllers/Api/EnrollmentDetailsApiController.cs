using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/enrollmentdetails")]
    public class EnrollmentDetailsApiController : BaseApiController<EnrollmentDetail>
    {
        public EnrollmentDetailsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        public override EnrollmentDetail Get(int id)
        {
            throw new NotImplementedException();
        }

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

        public override HttpResponseMessage Delete(int id)
        {
            throw new NotImplementedException();
        }

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
    }
}