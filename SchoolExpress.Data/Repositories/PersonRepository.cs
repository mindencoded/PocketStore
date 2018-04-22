using System.Data.Entity;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Repositories
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}