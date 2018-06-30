using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Repositories;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api.Crud
{
    [Authorize]
    [RoutePrefix("api/crud/enrollmentdetails")]
    public class EnrollmentDetailsCrudApiController : CrudApiController<EnrollmentDetail>
    {
        public EnrollmentDetailsCrudApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [HttpGet]
        [Authorize(Roles = "api.crud.enrollmentdetails.get")]
        [Route("{careerDetailId:int}/{enrollmentId:int}")]
        public EnrollmentDetail Get(int careerDetailId, int enrollmentId)
        {
            EnrollmentDetail enrollmentDetail =
                Uow.GetRepository<IEnrollmentDetailRepository>().GetAll()
                    .FirstOrDefault(x => x.CareerDetailId == careerDetailId && x.EnrollmentId == enrollmentId);
            if (enrollmentDetail != null)
                return enrollmentDetail;
            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        [HttpDelete]
        [Authorize(Roles = "api.crud.enrollmentdetails.delete")]
        [Route("{careerDetailId:int}/{enrollmentId:int}")]
        public HttpResponseMessage Delete(int careerDetailId, int enrollmentId)
        {
            EnrollmentDetail enrollmentDetail =
                Uow.GetRepository<IEnrollmentDetailRepository>().GetAll()
                    .FirstOrDefault(x => x.CareerDetailId == careerDetailId && x.EnrollmentId == enrollmentId);
            if (enrollmentDetail != null)
            {
                Uow.GetRepository<IEnrollmentDetailRepository>().Delete(enrollmentDetail);
                Uow.Commit();
                return new HttpResponseMessage(HttpStatusCode.NoContent);
            }

            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        [Authorize(Roles = "api.crud.enrollmentdetails.get")]
        public override IEnumerable<EnrollmentDetail> Get()
        {
            return base.Get();
        }

        [Authorize(Roles = "api.crud.enrollmentdetails.get")]
        public override Task<EnrollmentDetail> Get(object id)
        {
            throw new NotImplementedException();
        }


        [Authorize(Roles = "api.crud.enrollmentdetails.put")]
        protected override async Task<HttpResponseMessage> Put(EnrollmentDetail entity)
        {
            return await base.Put(entity);
        }


        [Authorize(Roles = "api.crud.enrollmentdetails.post")]
        public override async Task<HttpResponseMessage> Post(EnrollmentDetail entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.crud.enrollmentdetails.delete")]
        public override Task<HttpResponseMessage> Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}