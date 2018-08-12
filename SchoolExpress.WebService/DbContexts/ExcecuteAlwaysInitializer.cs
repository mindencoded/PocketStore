using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolExpress.WebService.DbContexts
{
    public class ExcecuteAlwaysInitializer : IDatabaseInitializer<SchoolExpressDbContext>
    {
        public void InitializeDatabase(SchoolExpressDbContext context)
        {
            IList<AuthorizeAttribute> authorizeAttributes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => typeof(ApiController).IsAssignableFrom(type))
                .SelectMany(type => type.GetMethods())
                .Where(method => method.IsPublic && method.IsDefined(typeof(AuthorizeAttribute), true))
                .Select(m => m.GetCustomAttributes(typeof(AuthorizeAttribute), true).First() as AuthorizeAttribute).ToList();
            UserManager<IdentityUser> userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
            RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));


            IdentityUser admin = userManager.FindByName("admin");
            if (admin == null)
            {
                admin = new IdentityUser
                {
                    UserName = "admin"
                };
                userManager.Create(admin, "admin123");
            }

           IList<string> roles = authorizeAttributes.Select(a => a.Roles).Distinct().ToList();
           IList<string> existingRoles = userManager.GetRoles(admin.Id);

            foreach (string role in roles)
            {
                bool exist = false;
                foreach (string existingRole in existingRoles)
                {
                    if (existingRole == role)
                    {
                        exist = true;
                        break;
                    }
                }

                if (!exist)
                {
                    roleManager.Create(new IdentityRole { Name = role});                  
                }

                if (!userManager.IsInRole(admin.Id, role))
                {
                    userManager.AddToRole(admin.Id, role);
                }
                
            }
            
            foreach (string existingRole in existingRoles)
            {
                bool exist = false;
                foreach (string role in roles)
                {
                    if (existingRole == role)
                    {
                        exist = true;
                        break;
                    }
                }

                if (!exist)
                {
                    IdentityRole roleToRemove = roleManager.FindByName(existingRole);
                    if (roleToRemove != null)
                    {
                        roleManager.Delete(roleToRemove);
                    }
                }
            }

        }
    }
}