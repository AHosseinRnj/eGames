using eGames.Data;
using eGames.Data.ViewModels;
using eGames.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eGames.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly AppDbContext _appDbContext;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _appDbContext = appDbContext;
        }

        public IActionResult Login()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if(!ModelState.IsValid)
                return View(loginVM);

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);
            if (user != null)
            {
                var passwordCheck = await _userManager.CheckPasswordAsync(user, loginVM.Password);
                if (passwordCheck)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);
                    if (result.Succeeded)
                        return RedirectToAction("Index", "Games");
                }

                TempData["Error"] = "Wrong credentials. Please, Try again!";
                return View(loginVM);
            }

            TempData["Error"] = "Wrong credentials. Please, Try again!";
            return View(loginVM);
        }

        public IActionResult Signup()
        {
            return View(new SignupVM());
        }
    }
}