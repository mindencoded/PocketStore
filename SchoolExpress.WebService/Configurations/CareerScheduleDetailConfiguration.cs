using System.Data.Entity.ModelConfiguration;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Configurations
{
    public class CareerScheduleDetailConfiguration : EntityTypeConfiguration<CareerScheduleDetail>
    {
        public CareerScheduleDetailConfiguration()
        {
            Property(x => x.Day).HasMaxLength(3);
            Property(x => x.StartTime).IsOptional();
            Property(x => x.EndTime).IsOptional();
        }
    }
}