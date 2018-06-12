namespace SchoolExpress.Domain
{
    public class EnrollmentDetail : Entity
    {
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public int EnrollmentId { get; set; }

        public virtual Enrollment Enrollment { get; set; }

        public decimal Discount { get; set; }

        public override object[] GetId()
        {
            return new object[] {CourseId, EnrollmentId};
        }
    }
}