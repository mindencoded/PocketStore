using System;
using System.ComponentModel.DataAnnotations;

namespace SchoolExpress.WebService.Models
{
    public class SpeakerCareerScheduleDetailModel
    {
        public int Id { get; set; }

        public TimeSpan? StartTime { get; set; }

        public TimeSpan? EndTime { get; set; }

        public string Day { get; set; }

        [Display(Name ="Career")]
        public string CareerDescription { get; set; }

        [Display(Name = "Course")]
        public string CourseDescription { get; set; }
    }
}
