using System.ComponentModel.DataAnnotations;

namespace SchoolExpress.WebService.Models
{
    public class AudienceModel
    {
        [MaxLength(100)] [Required] public string Name { get; set; }
    }
}