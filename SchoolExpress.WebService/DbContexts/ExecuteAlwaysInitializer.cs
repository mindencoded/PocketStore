using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using SchoolExpress.WebService.Domain;
using SchoolExpress.WebService.Utils;

namespace SchoolExpress.WebService.DbContexts
{
    public class ExecuteAlwaysInitializer : IDatabaseInitializer<SchoolExpressDbContext>
    {
        public void InitializeDatabase(SchoolExpressDbContext context)
        {
            if(!context.Database.Exists())
            {
                return;
            }

            IList<AuthorizeAttribute> authorizeAttributes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => typeof(ApiController).IsAssignableFrom(type))
                .SelectMany(type => type.GetMethods())
                .Where(method => method.IsPublic && method.IsDefined(typeof(AuthorizeAttribute), true))
                .Select(m => m.GetCustomAttributes(typeof(AuthorizeAttribute), true).First() as AuthorizeAttribute).ToList();
            string[] controllerRoles = authorizeAttributes.Select(a => a.Roles).Distinct().ToArray();
            
           DbSet<User> userDbSet = context.Set<User>();
           User user = userDbSet.FirstOrDefault(x => x.UserName == "admin");
            if (user == null)
            {
                user = new User
                {
                    UserName = "admin",
                    Email = "admin@schoolexpress.com",
                    Password = Md5Tool.CreateUtf8Hash("admin123")
                };
                userDbSet.Add(user);
                context.SaveChanges();
            }

            DbSet<Role>  roleDbSet = context.Set<Role>();
            DbSet<UserRole> userRoleDbSet = context.Set<UserRole>();
            
           string[] existingRoles = userRoleDbSet.AsNoTracking().Include(x => x.Role).Where(x => x.UserId == user.Id).Select(x => x.Role.Name).ToArray();

            foreach (string roleName in controllerRoles)
            {
                bool exist = false;
                Role role = new Role { Name = roleName };

                foreach (string existingRole in existingRoles)
                {
                    if (existingRole == roleName)
                    {
                        exist = true;
                        break;
                    }
                }

                if (!exist)
                {
                    roleDbSet.Add(role);
                    context.SaveChanges();
                    context.Entry(role).State = EntityState.Detached;
                }

                if (!existingRoles.Contains(roleName))
                {
                    //int roleId = roleDbSet.AsNoTracking().Where(x => x.Name == roleName).Select(x => x.Id).First();
                    UserRole userRole = new UserRole
                    {
                        UserId = user.Id,
                        RoleId = role.Id
                    };
                    userRoleDbSet.Add(userRole);
                    context.SaveChanges();
                    context.Entry(userRole).State = EntityState.Detached;
                }
            }
            
            foreach (string existingRoleName in existingRoles)
            {
                bool exist = false;
                foreach (string roleName in controllerRoles)
                {
                    if (existingRoleName == roleName)
                    {
                        exist = true;
                        break;
                    }
                }

                if (!exist)
                {
                    Role role = roleDbSet.AsNoTracking().FirstOrDefault(x => x.Name == existingRoleName);
                    if (role != null)
                    {
                        roleDbSet.Attach(role);
                        roleDbSet.Remove(role);
                        context.SaveChanges();
                        context.Entry(role).State = EntityState.Detached;
                    }
                }
            }

        }
    }
}