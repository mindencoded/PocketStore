using System.Collections.Generic;

namespace SchoolExpress.WebService.Models
{
    public class SpeakerCareerScheduleModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public virtual IEnumerable<SpeakerCareerScheduleDetailModel> CareerScheduleBySpeakerDetails { get; set; }
    }
}
