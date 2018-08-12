using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolExpress.WebService.Uows
{
    public interface ISchoolExpressUow : IUow
    {
        UserManager<IdentityUser> UserManager();

        RoleManager<IdentityRole> RoleManager();
    }
}