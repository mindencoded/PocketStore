using System.Data.Entity.ModelConfiguration;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Configurations
{
    public class CareerScheduleDetailConfiguration : EntityTypeConfiguration<CareerScheduleDetail>
    {
        public CareerScheduleDetailConfiguration()
        {
            Property(x => x.Day).HasMaxLength(3);
            Property(x => x.Day).HasColumnType("char");
            Property(x => x.StartTime).IsOptional();
            Property(x => x.EndTime).IsOptional();
        }
    }
}