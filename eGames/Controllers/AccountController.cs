using eGames.Data;
using eGames.Data.Static;
using eGames.Data.ViewModels;
using eGames.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> Users()
        {
            var users = await _appDbContext.Users.ToListAsync();
            return View(users);
        }

        public IActionResult Login()
        {
            return View(new LoginVM());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
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

        [HttpPost]
        public async Task<IActionResult> Signup(SignupVM signupVM)
        {
            if (!ModelState.IsValid)
                return View(signupVM);

            var user = await _userManager.FindByEmailAsync(signupVM.EmailAddress);
            if (user != null)
            {
                TempData["Error"] = "This mail address is already in use";
                return View(signupVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = signupVM.FullName,
                Email = signupVM.EmailAddress,
                UserName = signupVM.EmailAddress,

            };

            var newUserResponse = await _userManager.CreateAsync(newUser, signupVM.Password);
            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);
                return View("RegisterCompleted");
            }
            else
            {
                var errors = string.Empty;
                var errorCount = 1;
                foreach (var error in newUserResponse.Errors)
                {
                    errors += " (" + errorCount + ") " + error.Description;
                    errorCount++;
                }

                TempData["Error"] = $"Error(s): {errors}";
                return View(signupVM);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Games");
        }
    }
}