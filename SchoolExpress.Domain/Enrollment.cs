using System;
using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class Enrollment : Entity
    {
        public int Id { get; set; }

        public DateTime InscriptionDate { get; set; }

        public decimal TotalAmount { get; set; }

        public int StudentId { get; set; }

        public virtual Person Student { get; set; }

        public virtual ICollection<EnrollmentDetail> EnrollmentDetails { get; set; }

        public override object[] GetId()
        {
            return new object[] {Id};
        }
    }
}