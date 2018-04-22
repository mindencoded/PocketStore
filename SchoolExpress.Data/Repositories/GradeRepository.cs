using System.Data.Entity;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Repositories
{
    public class GradeRepository : Repository<Grade>, IGradeRepository
    {
        public GradeRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}