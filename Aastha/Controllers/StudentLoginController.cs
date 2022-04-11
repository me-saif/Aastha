// using System.Threading.Tasks;
// using Aastha.Data.Models;
// using Aastha.Data.ViewModels;
// using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Mvc;

// namespace Aastha.Controllers
// {
//     public class StudentLoginController: Controller
//     {
//        private readonly UserManager<IdentityUser> _userManager;
//         private readonly SignInManager<Student> _signInManager;

//         public StudentLoginController(UserManager<IdentityUser> userManager, SignInManager<Student> signInManager)
//         {
//             _userManager = userManager;
//             _signInManager = signInManager;
//         }

//         [HttpGet]
//         public IActionResult Login()
//         {
//             return View();
//         }

//         [HttpPost]
//         public async Task<IActionResult> Login(StudentLoginViewModel model)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return NotFound();
//             }

//             var success = await _signInManager.PasswordSignInAsync(model.Mobile_No, model.Password, true, false);

//             if (success.Succeeded)
//             {
//                 return RedirectToAction("Index","Student");
//             }
//             return View("Login");
//         }

//     }
// }