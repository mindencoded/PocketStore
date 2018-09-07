using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Repositories;
using SchoolExpress.WebService.Uows;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.Controllers.Api.Cruds
{
    [Authorize]
    [RoutePrefix("api/cruds/enrollmentdetails")]
    public class EnrollmentDetailsCrudApiController : CrudApiController<EnrollmentDetail>
    {
        public EnrollmentDetailsCrudApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [HttpGet]
        [Authorize(Roles = "api.cruds.enrollmentdetails.get")]
        [Route("{careerDetailId:int}/{enrollmentId:int}")]
        public async Task<HttpResponseMessage> Get(int careerDetailId, int enrollmentId)
        {
            EnrollmentDetail enrollmentDetail =
                await Uow.GetRepository<IEnrollmentDetailRepository>().GetAll()
                    .FirstOrDefaultAsync(x => x.CareerDetailId == careerDetailId && x.EnrollmentId == enrollmentId);
            if (enrollmentDetail != null)
                return Request.CreateResponse(HttpStatusCode.OK, enrollmentDetail, new JsonMediaTypeFormatter(),
                    new MediaTypeHeaderValue("application/json"));

            throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.NotFound));
        }

        [HttpDelete]
        [Authorize(Roles = "api.cruds.enrollmentdetails.delete")]
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

        [Authorize(Roles = "api.cruds.enrollmentdetails.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy)
        {
            return base.Get(page, pageSize, orderBy);
        }

        [Authorize(Roles = "api.cruds.enrollmentdetails.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy, string where)
        {
            return base.Get(page, pageSize, orderBy, where);
        }
        
        [Authorize(Roles = "api.cruds.enrollmentdetails.get")]
        public override Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy, string where, string select)
        {
            return base.Get(page, pageSize, orderBy, where, select);
        }

        [Authorize(Roles = "api.cruds.enrollmentdetails.get")]
        public override Task<HttpResponseMessage> Get(object id)
        {
            throw new NotImplementedException();
        }


        [Authorize(Roles = "api.cruds.enrollmentdetails.put")]
        public override async Task<HttpResponseMessage> Put(EnrollmentDetail entity)
        {
            return await base.Put(entity);
        }


        [Authorize(Roles = "api.cruds.enrollmentdetails.post")]
        public override async Task<HttpResponseMessage> Post(EnrollmentDetail entity)
        {
            return await base.Post(entity);
        }

        [Authorize(Roles = "api.cruds.enrollmentdetails.delete")]
        public override Task<HttpResponseMessage> Delete(object id)
        {
            throw new NotImplementedException();
        }
    }
}