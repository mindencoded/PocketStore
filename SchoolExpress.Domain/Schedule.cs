using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class Schedule : EntityBaseIdentity
    {
        public string Description { get; set; }

        public int AcademicTermId { get; set; }

        public virtual AcademicTerm AcademicTerm { get; set; }

        public int GradeId { get; set; }

        public virtual Grade Grade { get; set; }

        public virtual ICollection<ScheduleDetail> ScheduleDetails { get; set; }
    }
}