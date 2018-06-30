using System.Data.Entity.ModelConfiguration;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Configurations
{
    public class UserAccountConfiguration : EntityTypeConfiguration<UserAccount>
    {
        public UserAccountConfiguration()
        {
            HasKey(x => new { x.UserId, x.PersonId });
            HasRequired(e => e.Person)
                .WithMany(e => e.UserAccounts)
                .HasForeignKey(e => new { e.PersonId })
                .WillCascadeOnDelete(false);
            HasRequired(e => e.User)
                .WithMany()
                .HasForeignKey(e => new { e.UserId })
                .WillCascadeOnDelete(false);
        }
    }
}
