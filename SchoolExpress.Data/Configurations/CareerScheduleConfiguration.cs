using System.Data.Entity.ModelConfiguration;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Configurations
{
    public class CareerScheduleConfiguration : EntityTypeConfiguration<CareerSchedule>
    {
        public CareerScheduleConfiguration()
        {
            HasIndex(x => new { x.Description }).IsUnique();
            Property(x => x.Description).IsRequired();
        }
    }
}