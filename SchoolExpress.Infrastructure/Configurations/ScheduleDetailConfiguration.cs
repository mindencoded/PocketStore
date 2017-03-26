using System.Data.Entity.ModelConfiguration;
using SchoolExpress.Domain;

namespace SchoolExpress.Infrastructure.Configurations
{
    internal class ScheduleDetailConfiguration : EntityTypeConfiguration<ScheduleDetail>
    {
        public ScheduleDetailConfiguration()
        {
            //HasKey(x => x.Id);
            Ignore(x => x.Days);
            HasRequired(x => x.Schedule)
                .WithMany(x => x.ScheduleDetails)
                .HasForeignKey(x => x.ScheduleId)
                .WillCascadeOnDelete(false);
            ;
            //HasRequired(x => x.Course).WithMany(x => x.ScheduleDetails).HasForeignKey(x => x.CourseId);
            //HasRequired(x => x.ClassRoom).WithMany(x => x.ScheduleDetails).HasForeignKey(x => x.ClassRoomId);
            HasRequired(x => x.Teacher)
                .WithMany(x => x.ScheduleDetails)
                .HasForeignKey(x => x.TeacherId)
                .WillCascadeOnDelete(false);
            ;
        }
    }
}