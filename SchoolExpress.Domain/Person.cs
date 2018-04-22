using System;
using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class Person : Entity
    {
        public int Id { get; set; }

        public string Document { get; set; }

        public string InternalCode { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public virtual ICollection<CourseScheduleDetail> CourseScheduleDetails { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}