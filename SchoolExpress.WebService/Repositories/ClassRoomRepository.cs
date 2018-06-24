using System.Data.Entity;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class ClassRoomRepository : Repository<ClassRoom>, IClassRoomRepository
    {
        public ClassRoomRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}