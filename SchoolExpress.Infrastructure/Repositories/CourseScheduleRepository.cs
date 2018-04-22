using System.Data.Entity;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.Infrastructure.Repositories
{
    public class CourseScheduleRepository : Repository<CourseSchedule>, ICourseScheduleRepository
    {
        public CourseScheduleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}