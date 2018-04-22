using System.Data.Entity;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Repositories
{
    public class CourseRepository : Repository<Course>, ICourseRepository
    {
        public CourseRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}