using System.Data.Entity;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Repositories
{
    public class SpeakerRepository : Repository<Speaker>, ISpeakerRepository
    {
        public SpeakerRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
