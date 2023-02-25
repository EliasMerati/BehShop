using System.ComponentModel.DataAnnotations;

namespace BehShop.Web.Models.ViewModels.Register
{
#nullable disable
    public class RegisterViewModel
    {

        [Display(Name = "نام و نام خانوادگی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نباید بیشتر از {1} باشد")]
        public string FullName { get; set; }


        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [EmailAddress]
        [MaxLength(100,ErrorMessage ="{0} نباید بیشتر از {1} باشد")]
        public string Email { get; set; }

        [Display(Name = "شماره تلفن")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100, ErrorMessage = "{0} نباید بیشتر از {1} باشد")]
        public string PhoneNumber { get; set; }


        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="کلمه های عبور مغایرت دارند")]
        public string RePassword { get; set; }


    }
}
