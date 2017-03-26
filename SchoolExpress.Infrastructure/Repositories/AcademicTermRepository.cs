using System.Data.Entity;
using SchoolExpress.Domain;
using SchoolExpress.Infrastructure.Contracts;

namespace SchoolExpress.Infrastructure.Repositories
{
    public class AcademicTermRepository : Repository<AcademicTerm>, IAcademicTermRepository
    {
        public AcademicTermRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}