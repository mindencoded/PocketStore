using System.Collections.Generic;

namespace SchoolExpress.WebService.Domain
{
    public class Enrollment : Entity
    {
        public int Id { get; set; }

        public decimal Total { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public virtual ICollection<EnrollmentDetail> EnrollmentDetails { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}