using System.Collections.Generic;

namespace SchoolExpress.WebService.Domain
{
    public class ClassRoom : Entity
    {
        public int Id { get; set; }
        
        public int CampusId { get; set; }

        public virtual Campus Campus { get; set; }

        public string Description { get; set; }

        public virtual ICollection<CareerScheduleDetail> CareerScheduleDetails { get; set; }
        
        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}