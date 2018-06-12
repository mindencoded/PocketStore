

using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class Career : Entity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int DegreeId { get; set; }

        public virtual Degree Degree { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
        
        public override object[] GetId()
        {
            return new object[] { Id };
        }
    }
}
