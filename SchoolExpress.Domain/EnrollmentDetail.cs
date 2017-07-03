namespace SchoolExpress.Domain
{
    public class EnrollmentDetail : EntityBase
    {
        public int AssignmentId { get; set; }

        public virtual Assignment Assignment { get; set; }

        public int EnrollmentId { get; set; }

        public virtual Enrollment Enrollment { get; set; }

        public decimal Discount { get; set; }

        public override int[] IdentityKey()
        {
            return new[] {AssignmentId, EnrollmentId};
        }
    }
}