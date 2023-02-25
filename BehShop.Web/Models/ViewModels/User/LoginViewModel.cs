using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace BehShop.Web.Models.ViewModels.User
{
#nullable disable
    public class LoginViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress]
        [MaxLength(100, ErrorMessage = "{0} نباید بیشتر از {1} باشد")]
        public string Email { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "مرا به خاطر بسپار")]
        public bool IsPersistent { get; set; }

        public string ReturnURL { get; set; }
    }
}
