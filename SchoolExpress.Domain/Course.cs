using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class Course : Entity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int Hours { get; set; }

        public decimal CostByHour { get; set; }

        public int CareerId { get; set; }

        public virtual Career Career { get; set; }

        public virtual ICollection<CourseScheduleDetail> CourseScheduleDetails { get; set; }

        public virtual ICollection<EnrollmentDetail> EnrollmentDetails { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}