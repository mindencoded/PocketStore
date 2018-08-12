using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Configurations
{
    public class PeriodConfiguration : EntityTypeConfiguration<Period>
    {
        public PeriodConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasIndex(x => new {x.Description}).IsUnique();
            Property(x => x.Description).IsRequired();
            Property(x => x.StartDate).IsOptional();
            Property(x => x.EndDate).IsOptional();
        }
    }
}