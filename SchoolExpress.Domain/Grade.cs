using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class Grade : EntityBaseIdentity
    {
        public string Description { get; set; }

        public virtual ICollection<Course> Courses { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}