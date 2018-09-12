namespace SchoolExpress.WebService.Domain
{
    public class UserRole : Entity
    {
        public int UserId { get; set; }
        
        public virtual User User { get; set; }
        
        public int RoleId { get; set; }
        
        public virtual Role Role { get; set; }
        
        public override object[] GetId()
        {
            return new object[] { UserId, RoleId };
        }
    }
}