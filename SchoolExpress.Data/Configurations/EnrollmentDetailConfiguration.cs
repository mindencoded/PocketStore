using System.Data.Entity.ModelConfiguration;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Configurations
{
    internal class EnrollmentDetailConfiguration : EntityTypeConfiguration<EnrollmentDetail>
    {
        public EnrollmentDetailConfiguration()
        {
            HasKey(x => new {x.CourseId, x.EnrollmentId});

            HasRequired(x => x.Course)
                .WithMany(x => x.EnrollmentDetails)
                .HasForeignKey(x => x.CourseId);

            HasRequired(x => x.Enrollment)
                .WithMany(x => x.EnrollmentDetails)
                .HasForeignKey(x => x.EnrollmentId);
        }
    }
}