using System.Collections.Generic;

namespace SchoolExpress.WebService.Domain
{
    public class Career : Entity
    {
        public int Id { get; set; }
        
        public string Description { get; set; }

        public int DegreeId { get; set; }

        public virtual Degree Degree { get; set; }

        public virtual ICollection<CareerDetail> CareerDetails { get; set; }

        public virtual ICollection<CareerSchedule> CareerSchedules { get; set; }
        
        public override object[] GetId()
        {
            return new object[] { Id };
        }
    }
}