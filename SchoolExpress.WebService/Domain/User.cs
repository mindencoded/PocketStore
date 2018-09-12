using System.Collections.Generic;

namespace SchoolExpress.WebService.Domain
{
    public class User : Entity
    {
        public int Id { get; set; }
        
        public string UserName { get; set; }
        
        public string Password { get; set; }
        
        public string Email { get; set; }
        
        public virtual ICollection<UserRole> UserRoles { get; set; }

        public virtual ICollection<UserAccount> UserAccounts { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}