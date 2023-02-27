using BehShop.Common.Filters;
using BehShop.Domain.Entities.User;
using BehShop.Web.Models.ViewModels.Register;
using BehShop.Web.Models.ViewModels.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BehShop.Web.Controllers
{
    [ServiceFilter(typeof(ServiceVisitorFilter))]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        #region Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid) { return View(model); }
            var user = new User()
            {
                FullName= model.FullName,
                Email= model.Email,
                UserName=model.Email,
                PhoneNumber=model.PhoneNumber,
            };
           var result = _userManager.CreateAsync(user, model.Password).Result;
            if (result.Succeeded)
            {
                return RedirectToAction(nameof(Profile));
            }
            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(item.Code, item.Description);
            }
            return View(model);
        }
        #endregion

        #region Login
        public IActionResult Login(string Returnurl ="/")
        {
            return View(new LoginViewModel
            {
                ReturnURL= Returnurl
            });
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
             var user =_userManager.FindByNameAsync(login.Email).Result;
            if (user is null)
            {
                ModelState.AddModelError("", "کاربری با مشخصات فوق یافت نشد");
                return View(login);
            }
            _signInManager.SignOutAsync();
            var result = _signInManager.PasswordSignInAsync(user, login.Password, login.IsPersistent, true).Result;
            if (result.Succeeded)
            {
                return Redirect(login.ReturnURL);
            }

            return View(login);
        }
        #endregion

        #region SignOut
        public IActionResult SignOut()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Profile
        public IActionResult Profile()
        {

            return View();
        }
        #endregion


    }
}
