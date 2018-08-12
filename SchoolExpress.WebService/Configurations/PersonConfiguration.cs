using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Configurations
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasIndex(x => new {x.IdentityCard}).IsUnique();
            HasIndex(x => new {x.Email}).IsUnique();
            Property(x => x.Email).IsRequired();
            Property(x => x.Name).IsRequired();
        }
    }
}