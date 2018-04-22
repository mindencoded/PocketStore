using System.Data.Entity;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.Infrastructure.Repositories
{
    public class CourseScheduleDetailRepository : Repository<CourseScheduleDetail>, ICourseScheduleDetailRepository
    {
        public CourseScheduleDetailRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}