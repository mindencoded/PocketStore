using System.Data.Entity;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Repositories
{
    public class CourseScheduleDetailRepository : Repository<CourseScheduleDetail>, ICourseScheduleDetailRepository
    {
        public CourseScheduleDetailRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}