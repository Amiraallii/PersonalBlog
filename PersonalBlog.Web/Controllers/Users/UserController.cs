using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PersonalBlog.Data.Models;
using Blog.Business.IServices;

namespace PersonalBlog.Web.Controllers.Users
{
    public class UserController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IRegister _register;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,IRegister register)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _register = register;
        }




        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        public async Task<IActionResult> Register(User user)
        {

            if(ModelState.IsValid)
            {
                var result = await _register.RegisterUserAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var err in result.Errors)
                    {
                        ModelState.AddModelError("", err.Description);
                    }
                }
            }
            return View();

        }
    }
}
