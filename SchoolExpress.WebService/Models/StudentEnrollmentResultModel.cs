using System;
using System.Collections.Generic;

namespace SchoolExpress.WebService.Models
{
    public class StudentEnrollmentResultModel
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string StudentLastName { get; set; }
        public DateTime? Created { get; set; }
        public virtual IEnumerable<StudentEnrollmentDetailResultModel> StudentEnrollmentDetails { get; set; }
    }
}
