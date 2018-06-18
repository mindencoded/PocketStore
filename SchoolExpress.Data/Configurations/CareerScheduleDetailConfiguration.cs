using System.Data.Entity.ModelConfiguration;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Configurations
{
    public class CareerScheduleDetailConfiguration : EntityTypeConfiguration<CareerScheduleDetail>
    {
        public CareerScheduleDetailConfiguration()
        {
            Property(x => x.JoinDays).HasMaxLength(33);
            Property(x => x.StartTime).IsOptional();
            Property(x => x.EndTime).IsOptional();
        }
    }
}