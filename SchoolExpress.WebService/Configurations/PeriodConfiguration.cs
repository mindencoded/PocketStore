using System.Data.Entity.ModelConfiguration;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Configurations
{
    public class PeriodConfiguration : EntityTypeConfiguration<Period>
    {
        public PeriodConfiguration()
        {
            HasIndex(x => new {x.Description}).IsUnique();
            Property(x => x.Description).IsRequired();
            Property(x => x.StartDate).IsOptional();
            Property(x => x.EndDate).IsOptional();
        }
    }
}