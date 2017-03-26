using System;
using System.Collections.Generic;

namespace SchoolExpress.Domain
{
    public class Enrollment : EntityBaseIdentity
    {
        public DateTime InscriptionDate { get; set; }

        public decimal TotalAmount { get; set; }

        public int StudentId { get; set; }

        public virtual Person Student { get; set; }

        public virtual ICollection<EnrollmentDetail> EnrollmentDetails { get; set; }
    }
}