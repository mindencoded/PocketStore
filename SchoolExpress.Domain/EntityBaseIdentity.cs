namespace SchoolExpress.Domain
{
    public abstract class EntityBaseIdentity : EntityBase
    {
        public int Id { get; set; }

        public override int[] IdentityKey()
        {
            return new [] { Id };
        }
    }
}