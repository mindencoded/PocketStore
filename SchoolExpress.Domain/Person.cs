using System;
using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class Person : EntityBaseIdentity
    {
        public string Document { get; set; }

        public string InternalCode { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public DateTime Birthday { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }

        public virtual ICollection<User> Users { get; set; }

        public virtual ICollection<ScheduleDetail> ScheduleDetails { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }
}