
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SchoolExpress.WebService.Models
{
    public class StudentEnrollmentQueryModel : IValidatableObject
    {
        public int StudentId { get; set; }

        [Display(Name = "Start Date")]
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [Display(Name = "End Date")]
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (StartDate != null && EndDate != null && EndDate < StartDate)
            {
                yield return
                    new ValidationResult("EndDate must be greater than StartDate", new[] { "EndDate" });
            }
        }
    }
}
