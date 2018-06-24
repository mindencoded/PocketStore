using System.Collections.Generic;

namespace SchoolExpress.WebService.Domain
{
    public class Degree : Entity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Career> Carrers { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}