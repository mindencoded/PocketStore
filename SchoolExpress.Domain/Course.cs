using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class Course : Entity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public virtual ICollection<CareerDetail> CareerDetails { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}