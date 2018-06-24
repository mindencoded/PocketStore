using System.Data.Entity.ModelConfiguration;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Configurations
{
    public class CareerScheduleConfiguration : EntityTypeConfiguration<CareerSchedule>
    {
        public CareerScheduleConfiguration()
        {
            HasIndex(x => new {x.Description}).IsUnique();
            Property(x => x.Description).IsRequired();
            HasIndex(x => new {x.PeriodId, x.CareerId, x.ModuleId}).IsUnique();
        }
    }
}