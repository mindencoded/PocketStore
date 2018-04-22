using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class Role : Entity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Person> Persons { get; set; }

        public override object[] GetId()
        {
            return new object[] { Id };
        }
    }
}