using System.ComponentModel.DataAnnotations;

namespace SchoolExpress.WebService.Models
{
    public class ChangePasswordModel
    {
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(Name = "Old Password")]
        public string OldPassword { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(Name = "New Password")]
        public string NewPasswprd { get; set; }

        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(Name = "Repeat New Password")]
        public string RepeatNewPassword { get; set; }
    }
}