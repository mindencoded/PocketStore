using System;

namespace SchoolExpress.Domain
{
    public abstract class Entity : IEntity
    {
        protected Entity()
        {
            Status = true;
        }

        public DateTime LastModified { get; set; }

        public DateTime Created { get; set; }

        public bool Status { get; set; }

        public abstract object[] GetId();
    }
}