using System.Data.Entity.ModelConfiguration;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Configurations
{
    public class CampusConfiguration : EntityTypeConfiguration<Campus>
    {
        public CampusConfiguration()
        {
            HasIndex(x => new { x.Description }).IsUnique();
            Property(x => x.Description).IsRequired();
        }
    }
}