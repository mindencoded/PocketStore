using System;
using System.Collections.Generic;

namespace SchoolExpress.WebService.Domain
{
    public class Period : Entity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public virtual ICollection<CareerSchedule> CareerSchedules { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}