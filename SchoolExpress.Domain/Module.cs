using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class Module : Entity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public virtual ICollection<CareerSchedule> CareerSchedules { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}