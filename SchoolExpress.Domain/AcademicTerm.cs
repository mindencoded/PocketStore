using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class AcademicTerm : EntityBaseIdentity
    {
        public string Description { get; set; }

        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}