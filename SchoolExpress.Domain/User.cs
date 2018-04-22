namespace SchoolExpress.Domain
{
    public class User : Entity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public int PersonId { get; set; }

        public virtual Person Person { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}