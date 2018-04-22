﻿using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class ClassRoom : Entity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public virtual ICollection<ScheduleDetail> ScheduleDetails { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}