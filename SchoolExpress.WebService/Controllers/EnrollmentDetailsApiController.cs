using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.WebService.Controllers
{
    [RoutePrefix("api/enrollmentdetails")]
    public class EnrollmentDetailsApiController : BaseApiController<EnrollmentDetail>
    {
        private readonly ISchoolExpressUow _uow;

        public EnrollmentDetailsApiController(ISchoolExpressUow uow) : base(uow)
        {
            _uow = uow;
        }

        public override EnrollmentDetail Get(int id)
        {
            throw new NotImplementedException();
        }

        [Route("{assignment:int}/{enrollmentId:int}")]
        public EnrollmentDetail Get(int assignment, int enrollmentId)
        {
            var enrollmentDetail =
                _uow.GetRepository<IEnrollmentDetailRepository>().GetAll()
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
                _uow.GetRepository<IEnrollmentDetailRepository>().GetAll()
                    .FirstOrDefault(x => x.AssignmentId == assignment && x.EnrollmentId == enrollmentId);
            if (enrollmentDetail != null)
            {
                _uow.GetRepository<IEnrollmentDetailRepository>().Delete(enrollmentDetail);
                _uow.Commit();
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }
    }
}