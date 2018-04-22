namespace SchoolExpress.Domain
{
    public class EnrollmentDetail : Entity
    {
        public int AssignmentId { get; set; }

        public virtual Assignment Assignment { get; set; }

        public int EnrollmentId { get; set; }

        public virtual Enrollment Enrollment { get; set; }

        public decimal Discount { get; set; }

        public override object[] GetId()
        {
            return new object[] {AssignmentId, EnrollmentId};
        }
    }
}