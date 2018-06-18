using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class CareerSchedule : Entity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int CareerId { get; set; }

        public virtual Career Career { get; set; }

        public int PeriodId { get; set; }

        public virtual Period Period { get; set; }

        public int ModuleId { get; set; }

        public virtual Module Module { get; set; }

        public virtual ICollection<CareerScheduleDetail> CareerScheduleDetails { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}