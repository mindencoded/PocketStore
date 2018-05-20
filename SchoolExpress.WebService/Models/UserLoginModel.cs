using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SchoolExpress.WebService.Models
{
    public class UserLoginModel
    {
        [DisplayName("User name")]
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }

        [DisplayName("Remember me")] public bool RememberMe { get; set; }
    }
}