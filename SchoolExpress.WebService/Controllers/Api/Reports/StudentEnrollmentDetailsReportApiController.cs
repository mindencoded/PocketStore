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
    [RoutePrefix("api/reports/studentenrollmentdetails")]
    public class StudentEnrollmentDetailsReportApiController : ReportApiController<StudentEnrollmentResultModel,
        StudentEnrollmentQueryModel>
    {
        public StudentEnrollmentDetailsReportApiController(ISchoolExpressUow uow) : base(uow)
        {
        }

        [Authorize(Roles = "api.reports.studentenrollmentdetails.post")]
        public override async Task<HttpResponseMessage> Post(StudentEnrollmentQueryModel model)
        {
            return await base.Post(model);
        }

        [Authorize(Roles = "api.reports.studentenrollmentdetails.post")]
        public override async Task<HttpResponseMessage> Post(int page, int pageSize, string orderBy, StudentEnrollmentQueryModel model)
        {
            return await base.Post(page, pageSize, orderBy, model);
        }

        [Authorize(Roles = "api.reports.studentenrollmentdetails.post")]
        public override async Task<HttpResponseMessage> Post(int page, int pageSize, string orderBy, string where,StudentEnrollmentQueryModel model)
        {
            return await base.Post(page, pageSize, orderBy, where, model);
        }

        [Authorize(Roles = "api.reports.studentenrollmentdetails.post")]
        public override async Task<HttpResponseMessage> Post(int page, int pageSize, string orderBy, string where, string select, StudentEnrollmentQueryModel model)
        {
            return await base.Post(page, pageSize, orderBy, where, select, model);
        }

        protected override IQueryable<StudentEnrollmentResultModel> CreateReport(StudentEnrollmentQueryModel model)
        {
            IQueryable<StudentEnrollmentResultModel> query = Uow.GetRepositoryForEntityType<Enrollment>().GetQueryable()
                .AsNoTracking()
                .Include(e => e.Student.Person)
                .Include(e => e.EnrollmentDetails.Select(ed => ed.CareerDetail.Course)).Select(e =>
                new StudentEnrollmentResultModel
                {
                    StudentId = e.StudentId,
                    StudentName = e.Student.Person.Name,
                    StudentLastName = e.Student.Person.LastName,
                    Created = e.Created,
                    StudentEnrollmentDetails = e.EnrollmentDetails.Select(ed => new
                        StudentEnrollmentDetailResultModel
                        {
                            CourseId = ed.CareerDetail.CourseId,
                            CourseDescription = ed.CareerDetail.Course.Description,
                            CourseCode = ed.CareerDetail.Course.Code,
                        })
                });

            if (model != null)
            {
                if (model.StudentId > 0)
                {
                    query = query.Where(e => e.StudentId == model.StudentId);
                }


                if (model.StartDate != null && model.EndDate != null)
                {
                    query = query.Where(e => e.Created >= model.StartDate && e.Created <= model.EndDate);
                }
            }
            
            return query;
        }
    }
}
