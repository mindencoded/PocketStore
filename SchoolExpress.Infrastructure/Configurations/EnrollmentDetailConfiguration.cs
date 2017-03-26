using System.Data.Entity.ModelConfiguration;
using SchoolExpress.Domain;

namespace SchoolExpress.Infrastructure.Configurations
{
    internal class EnrollmentDetailConfiguration : EntityTypeConfiguration<EnrollmentDetail>
    {
        public EnrollmentDetailConfiguration()
        {
            HasKey(x => new {x.AssignmentId, x.EnrollmentId});
            HasRequired(x => x.Assignment)
                .WithMany(x => x.EnrollmentDetails)
                .HasForeignKey(x => x.AssignmentId)
                .WillCascadeOnDelete(false);
            HasRequired(x => x.Enrollment)
                .WithMany(x => x.EnrollmentDetails)
                .HasForeignKey(x => x.EnrollmentId)
                .WillCascadeOnDelete(false);
        }
    }
}