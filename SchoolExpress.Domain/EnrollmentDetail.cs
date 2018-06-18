namespace SchoolExpress.Domain
{
    public class EnrollmentDetail : Entity
    {
        public int CareerDetailId { get; set; }

        public virtual CareerDetail CareerDetail { get; set; }

        public int EnrollmentId { get; set; }

        public virtual Enrollment Enrollment { get; set; }

        public decimal Discount { get; set; }

        public override object[] GetId()
        {
            return new object[] {CareerDetailId, EnrollmentId};
        }
    }
}