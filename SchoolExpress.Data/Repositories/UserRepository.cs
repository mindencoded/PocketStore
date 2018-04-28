using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolExpress.Data.Repositories
{
    public class UserRepository : Repository<IdentityUser>, IUserRepository
    {
        protected UserStore<IdentityUser> UserStore { get; }

        protected UserManager<IdentityUser> UserManager { get; }

        public UserRepository(DbContext dbContext) : base(dbContext)
        {
            UserStore = new UserStore<IdentityUser>(DbContext);
            UserManager = new UserManager<IdentityUser>(UserStore);
        }

        public void Add(IdentityUser entity, string password)
        {
            UserManager.Create(entity, password);
        }

        public override void Add(IdentityUser entity)
        {
            throw new NotImplementedException();
        }

    }
}
