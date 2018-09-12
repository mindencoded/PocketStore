using System.Collections.Generic;

namespace SchoolExpress.WebService.Domain
{
    public class Speaker : Entity
    {
        public int Id { get; set; }
        
        public int PersonId { get; set; }

        public string Achievements { get; set; }

        public bool PartTime { get; set; }

        public virtual Person Person { get; set; }

        public virtual ICollection<CareerScheduleDetail> CareerScheduleDetails { get; set; }
        
        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}