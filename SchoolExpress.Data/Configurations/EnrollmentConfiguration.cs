using System.Data.Entity.ModelConfiguration;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Configurations
{
    internal class EnrollmentConfiguration : EntityTypeConfiguration<Enrollment>
    {
        public EnrollmentConfiguration()
        {
            HasRequired(x => x.Student)
                .WithMany(x => x.Enrollments)
                .HasForeignKey(x => x.StudentId);
        }
    }
}