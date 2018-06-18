using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class Person : Entity
    {
        public int Id { get; set; }

        public string IdentityCard { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Speaker> Speakers { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}