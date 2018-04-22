using System.Data.Entity;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Repositories
{
    public class ClassRoomRepository : Repository<ClassRoom>, IClassRoomRepository
    {
        public ClassRoomRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}