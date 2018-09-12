using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasIndex(x => x.UserName).IsUnique();
            HasIndex(x => x.Email).IsUnique();
        }
    }
}