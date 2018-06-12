
using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class Speaker : Entity
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public string Achievements { get; set; }

        public string Biography { get; set; }

        public virtual Person Person { get; set; }

        public virtual ICollection<CourseScheduleDetail> CourseScheduleDetails { get; set; }

        public override object[] GetId()
        {
            return new object[] { Id };
        }
    }
}
