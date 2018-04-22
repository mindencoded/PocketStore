using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class Grade : Entity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<CourseSchedule> CourseSchedules { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}