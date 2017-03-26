namespace SchoolExpress.Domain
{
    public class User : EntityBaseIdentity
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; }
    }
}