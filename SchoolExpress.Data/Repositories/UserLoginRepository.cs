using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolExpress.Data.Repositories
{
    public class UserLoginRepository : Repository<IdentityUserLogin>, IUserLoginRepository
    {
        public UserLoginRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
