using Microsoft.AspNet.Identity.EntityFramework;

namespace SchoolExpress.WebService.Domain
{
    public class UserAccount : Entity
    {
        public string UserId { get; set; }

        public virtual IdentityUser User { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

        public override object[] GetId()
        {
            return new object[] { UserId, PersonId };
        }
    }
}
