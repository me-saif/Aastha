using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Aastha.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Aastha.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("register")]
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var user = new IdentityUser
            {
                UserName = model.Email,
                Email = model.Email
            };

           var success = await _userManager.CreateAsync(user, model.Password);
           if (success.Succeeded)
           {
               await _userManager.AddToRoleAsync(user, "User");
               return RedirectToAction("Index", "User");
           }


           foreach (var error in success.Errors)
           {
               ModelState.AddModelError("",error.Description);
           }
            TempData["Success"] = "The data has been added...!";
            return View("Register");
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
            bool userMob = _userManager.Users.Any(item => item.PhoneNumber == model.PhoneNumber);
            if (user==null)
            {
                return NotFound();
            }

            var success = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);

            if (success.Succeeded)
            {
                return RedirectToAction("Index","Home");
            }

            return View("Login");
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }


        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
