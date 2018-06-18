using System.Data.Entity.ModelConfiguration;
using SchoolExpress.Domain;

namespace SchoolExpress.Data.Configurations
{
    public class EnrollmentDetailConfiguration : EntityTypeConfiguration<EnrollmentDetail>
    {
        public EnrollmentDetailConfiguration()
        {
            HasKey(x => new {x.CareerDetailId, x.EnrollmentId});
        }
    }
}