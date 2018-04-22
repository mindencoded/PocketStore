using System.Data.Entity;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Repositories
{
    public class CourseScheduleRepository : Repository<CourseSchedule>, ICourseScheduleRepository
    {
        public CourseScheduleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}