namespace SchoolExpress.Domain
{
    public class Audience : IEntity
    {
        public string ClientId { get; set; }

        public string Base64Secret { get; set; }

        public string Name { get; set; }

        public object[] GetId()
        {
            return new object[] {ClientId};
        }
    }
}