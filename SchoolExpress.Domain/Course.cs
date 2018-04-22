using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class Course : Entity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int GradeId { get; set; }

        public virtual Grade Grade { get; set; }

        public virtual ICollection<CourseScheduleDetail> CourseScheduleDetails { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}