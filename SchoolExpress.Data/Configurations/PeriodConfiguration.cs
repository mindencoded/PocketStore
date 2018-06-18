using System.Data.Entity.ModelConfiguration;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Configurations
{
    public class PeriodConfiguration : EntityTypeConfiguration<Period>
    {
        public PeriodConfiguration()
        {
            HasIndex(x => new { x.Description }).IsUnique();
            Property(x => x.Description).IsRequired();
            Property(x => x.StartDate).IsOptional();
            Property(x => x.EndDate).IsOptional();
        }
    }
}
