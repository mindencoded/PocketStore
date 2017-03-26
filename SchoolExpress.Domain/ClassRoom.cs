using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class ClassRoom : EntityBaseIdentity
    {
        public string Description { get; set; }

        public virtual ICollection<ScheduleDetail> ScheduleDetails { get; set; }
    }
}