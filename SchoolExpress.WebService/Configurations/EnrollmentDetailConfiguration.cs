using System.Data.Entity.ModelConfiguration;
using SchoolExpress.WebService.Domain;

namespace SchoolExpress.WebService.Configurations
{
    public class EnrollmentDetailConfiguration : EntityTypeConfiguration<EnrollmentDetail>
    {
        public EnrollmentDetailConfiguration()
        {
            HasKey(x => new {x.CareerDetailId, x.EnrollmentId});
        }
    }
}