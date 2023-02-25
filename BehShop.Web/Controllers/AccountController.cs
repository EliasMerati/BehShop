using BehShop.Domain.Entities.User;
using BehShop.Web.Models.ViewModels.Register;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BehShop.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        public AccountController(UserManager<User> userManager)
        {
            _userManager = userManager;
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

        public IActionResult Profile()
        {
            return View();
        }

    }
}
