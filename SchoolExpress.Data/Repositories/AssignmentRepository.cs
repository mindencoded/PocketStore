using System.Data.Entity;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Repositories
{
    public class AssignmentRepository : Repository<Assignment>, IAssignmentRepository
    {
        public AssignmentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}