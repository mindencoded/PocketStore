using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class Schedule : Entity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int AcademicTermId { get; set; }

        public virtual AcademicTerm AcademicTerm { get; set; }

        public int GradeId { get; set; }

        public virtual Grade Grade { get; set; }

        public virtual ICollection<ScheduleDetail> ScheduleDetails { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}