using System;

namespace SchoolExpress.Domain
{
    public abstract class Entity : IEntity
    {
        public DateTime LastModified { get; set; }

        public DateTime Created { get; set; }

        public bool Status { get; set; }
        public abstract object[] GetId();
    }
}