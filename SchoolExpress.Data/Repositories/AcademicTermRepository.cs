using System.Data.Entity;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Repositories
{
    public class AcademicTermRepository : Repository<AcademicTerm>, IAcademicTermRepository
    {
        public AcademicTermRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}