using System.Data.Entity.ModelConfiguration;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Configurations
{
    public class UserAccountConfiguration : EntityTypeConfiguration<UserAccount>
    {
        public UserAccountConfiguration()
        {
            HasKey(x => new { x.UserId, x.PersonId });
        }
    }
}
