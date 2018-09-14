using System.Data.Entity;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Models;
using SchoolExpress.WebService.Uows;

namespace SchoolExpress.WebService.Controllers.Api.Reports
{
    [RoutePrefix("api/reports/speakercareerschedules")]
    public class SpeakerCareerSchedulesReportApiController : ReportApiController<SpeakerCareerScheduleModel>
    {
        public SpeakerCareerSchedulesReportApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.reports.speakercareerschedules.get")]
        public override async Task<HttpResponseMessage> Get()
        {
            return await base.Get();
        }

        [Authorize(Roles = "api.reports.speakercareerschedules.get")]
        public override async Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy)
        {
            return await base.Get(page, pageSize, orderBy);
        }


        [Authorize(Roles = "api.reports.speakercareerschedules.get")]
        public override async Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy, string where)
        {
            return await base.Get(page, pageSize, orderBy, where);
        }


        [Authorize(Roles = "api.reports.speakercareerschedules.get")]
        public override async Task<HttpResponseMessage> Get(int page, int pageSize, string orderBy, string where, string select)
        {
            return await base.Get(page, pageSize, orderBy, where, select);
        }

        protected override IQueryable<SpeakerCareerScheduleModel> CreateReport()
        {
            IQueryable<SpeakerCareerScheduleModel> query = Uow.GetRepositoryForEntityType<Speaker>().GetQueryable().AsNoTracking()
                .Include(s => s.Person)
                .Include(s => s.CareerScheduleDetails.Select(csd => csd.CareerDetail.Career))
                .Include(s => s.CareerScheduleDetails.Select(csd => csd.CareerDetail.Course))
                .Where(s => s.Status)
                .Select(s => new SpeakerCareerScheduleModel
                {
                   Id = s.Id,
                   Name = s.Person.Name,
                   LastName = s.Person.LastName,
                   CareerScheduleBySpeakerDetails = s.CareerScheduleDetails.Where(csd => csd.Status).Select(csd => new SpeakerCareerScheduleDetailModel
                   {
                       Id = csd.Id,
                       Day = csd.Day,
                       StartTime = csd.StartTime,
                       EndTime = csd.EndTime,
                       CareerDescription = csd.CareerDetail.Career.Description,
                       CourseDescription = csd.CareerDetail.Course.Description
                   }).OrderBy(csd => csd.CareerDescription)
                });
            return query;
        }
    }
}
