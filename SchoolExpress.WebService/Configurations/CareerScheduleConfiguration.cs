using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Configurations
{
    public class CareerScheduleConfiguration : EntityTypeConfiguration<CareerSchedule>
    {
        public CareerScheduleConfiguration()
        {
            HasKey(x => x.Id);
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasIndex(x => new {x.Description}).IsUnique();
            Property(x => x.Description).IsRequired();
            HasIndex(x => new {x.PeriodId, x.CareerId, x.ModuleId}).IsUnique();
        }
    }
}