using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class Assignment : EntityBaseIdentity
    {
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public int Hours { get; set; }

        public decimal CostByHour { get; set; }

        public int Points { get; set; }

        public decimal CostByPoint { get; set; }

        public virtual ICollection<EnrollmentDetail> EnrollmentDetails { get; set; }
    }
}