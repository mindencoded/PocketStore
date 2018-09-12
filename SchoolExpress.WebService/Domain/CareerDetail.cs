using System.Collections.Generic;

namespace SchoolExpress.WebService.Domain
{
    public class CareerDetail : Entity
    {
        public int Id { get; set; }
        
        public decimal Credits { get; set; }

        public decimal CreditAmount { get; set; }

        public int CareerId { get; set; }

        public virtual Career Career { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<EnrollmentDetail> EnrollmentDetails { get; set; }

        public virtual ICollection<CareerScheduleDetail> CareerScheduleDetails { get; set; }
        
        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}