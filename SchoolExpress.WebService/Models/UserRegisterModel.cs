using System.ComponentModel.DataAnnotations;

namespace SchoolExpress.WebService.Models
{
    public class UserRegisterModel
    {
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [StringLength(100)]
        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Email")]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(100)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}