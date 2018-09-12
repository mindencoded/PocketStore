using System.Collections.Generic;

namespace SchoolExpress.WebService.Domain
{
    public class Role : Entity
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        
        public virtual ICollection<UserRole> UserRoles { get; set; }
        
        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}