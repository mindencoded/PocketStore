using System;

namespace SchoolExpress.WebService.Domain
{
    public class CareerScheduleDetail : Entity
    {
        public int Id { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        public string Day { get; set; }

        public int CareerScheduleId { get; set; }

        public virtual CareerSchedule CareerSchedule { get; set; }

        public int ClassRoomId { get; set; }

        public virtual ClassRoom ClassRoom { get; set; }

        public int SpeakerId { get; set; }

        public virtual Speaker Speaker { get; set; }

        public int CareerDetailId { get; set; }

        public virtual CareerDetail CareerDetail { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}