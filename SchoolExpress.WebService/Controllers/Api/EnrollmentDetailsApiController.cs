using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.Domain;
using SchoolExpress.Data.Repositories;
using SchoolExpress.Data.Uows;

namespace SchoolExpress.WebService.Controllers.Api
{
    [Authorize]
    [RoutePrefix("api/enrollmentdetails")]
    public class EnrollmentDetailsApiController : CrudApiController<EnrollmentDetail>
    {
        public EnrollmentDetailsApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [HttpGet]
        [Authorize(Roles = "api.enrollmentdetails.get")]
        [Route("{courseId:int}/{enrollmentId:int}")]
        public EnrollmentDetail Get(int courseId, int enrollmentId)
        {
            EnrollmentDetail enrollmentDetail =
                Uow.GetRepository<IEnrollmentDetailRepository>().GetAll()
                    .FirstOrDefault(x => x.CourseId == courseId && x.EnrollmentId == enrollmentId);
            if (enrollmentDetail != null)
                return enrollmentDetail;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        [HttpDelete]
        [Authorize(Roles = "api.enrollmentdetails.delete")]
        [Route("{courseId:int}/{enrollmentId:int}")]
        public HttpResponseMessage Delete(int courseId, int enrollmentId)
        {
            EnrollmentDetail enrollmentDetail =
                Uow.GetRepository<IEnrollmentDetailRepository>().GetAll()
                    .FirstOrDefault(x => x.CourseId == courseId && x.EnrollmentId == enrollmentId);
            if (enrollmentDetail != null)
            {
                Uow.GetRepository<IEnrollmentDetailRepository>().Delete(enrollmentDetail);
                Uow.Commit();
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }

            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        [Authorize(Roles = "api.enrollmentdetails.get")]
        public override IEnumerable<EnrollmentDetail> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.enrollmentdetails.get")]
        public override Task<EnrollmentDetail> Get(object id)
        {
            throw new NotImplementedException();
        }


        [Authorize(Roles = "api.enrollmentdetails.put")]
        protected override async Task<HttpResponseMessage> Put(EnrollmentDetail entity)
        {
            return await base.Put(entity);
        }


        [Authorize(Roles = "api.enrollmentdetails.post")]
        public override async Task<HttpResponseMessage> Post(EnrollmentDetail entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.enrollmentdetails.delete")]
        public override Task<HttpResponseMessage> Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}