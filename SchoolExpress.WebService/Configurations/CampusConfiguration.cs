using System.Data.Entity.ModelConfiguration;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Configurations
{
    public class CampusConfiguration : EntityTypeConfiguration<Campus>
    {
        public CampusConfiguration()
        {
            HasIndex(x => new {x.Description}).IsUnique();
            Property(x => x.Description).IsRequired();
        }
    }
}