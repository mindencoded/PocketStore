using System.Collections.Generic;

namespace SchoolExpress.WebService.Domain
{
    public class Student : Entity
    {
        public int Id { get; set; }

        public int PersonId { get; set; }

        public string SubscriptionId { get; set; }

        public virtual Person Person { get; set; }

        public virtual ICollection<Enrollment> Enrollments { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}