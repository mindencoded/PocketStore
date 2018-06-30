using SchoolExpress.WebService.DbContexts;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Repositories
{
    public class UserAccountRepository : Repository<UserAccount>, IUserAccountRepository
    {
        public UserAccountRepository(SchoolExpressDbContext dbContext) : base(dbContext)
        {
        }
    }
}
