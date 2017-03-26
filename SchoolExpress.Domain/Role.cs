using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class Role : EntityBaseIdentity
    {
        public string Description { get; set; }

        public virtual ICollection<Person> Persons { get; set; }
    }
}