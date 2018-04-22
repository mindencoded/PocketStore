using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class Assignment : Entity
    {
        public int Id { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public int Hours { get; set; }

        public decimal CostByHour { get; set; }

        public int Points { get; set; }

        public decimal CostByPoint { get; set; }

        public virtual ICollection<EnrollmentDetail> EnrollmentDetails { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}