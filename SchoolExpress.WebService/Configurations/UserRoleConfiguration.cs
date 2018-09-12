using System.Data.Entity.ModelConfiguration;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Configurations
{
    public class UserRoleConfiguration : EntityTypeConfiguration<UserRole>
    {
        public UserRoleConfiguration()
        {
            HasKey(x => new {x.UserId, x.RoleId});
        }
    }
}