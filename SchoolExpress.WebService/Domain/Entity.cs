﻿using System;

namespace SchoolExpress.WebService.Domain
{
    public abstract class Entity : IEntity
    {
        protected Entity()
        {
            Status = true;
            Created = DateTime.Now;
            LastModified = DateTime.Now;
        }

        public DateTime LastModified { get; set; }

        public DateTime Created { get; set; }

        public bool Status { get; set; }

        public abstract object[] GetId();
    }
}