using System;

namespace SchoolExpress.Domain
{
    public abstract class EntityBase : IEntityBase
    {
        public DateTime LastModified { get; set; }

        public DateTime Created { get; set; }

        public bool Status { get; set; }

        public abstract int[] IdentityKey();
    }
}