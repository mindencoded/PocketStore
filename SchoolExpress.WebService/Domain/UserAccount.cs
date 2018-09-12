namespace SchoolExpress.WebService.Domain
{
    public class UserAccount : Entity
    {
        public int UserId { get; set; }

        public virtual User User { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

        public override object[] GetId()
        {
            return new object[] { UserId, PersonId };
        }
    }
}
