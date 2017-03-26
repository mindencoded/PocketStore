using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class Course : EntityBaseIdentity
    {
        public string Description { get; set; }

        public int GradeId { get; set; }

        public virtual Grade Grade { get; set; }

        public virtual ICollection<ScheduleDetail> ScheduleDetails { get; set; }

        public virtual ICollection<Assignment> Assignments { get; set; }
    }
}