using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class CourseSchedule : Entity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int AcademicTermId { get; set; }

        public virtual AcademicTerm AcademicTerm { get; set; }
        
        public virtual ICollection<CourseScheduleDetail> CourseScheduleDetails { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}