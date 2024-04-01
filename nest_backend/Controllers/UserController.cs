using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using nest_backend.Helpers;
using nest_backend.Models;
using nest_backend.ViewModels;
using System.Threading.Tasks;

namespace nest_backend.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        public UserController(UserManager<AppUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            AppUser appUser = new AppUser()
            {
                FullName = registerViewModel.FullName,
                UserName = registerViewModel.Username,
                Email = registerViewModel.Email
            };

            IdentityResult identityResult = await _userManager.CreateAsync(appUser, registerViewModel.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerViewModel);
            }

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);
            string link = Url.Action("ConfirmEmail", "Auth", new { email = appUser.Email, token }, HttpContext.Request.Scheme, HttpContext.Request.Host.Value);
            string body = $"<a href='{link}'>Confirm your email</a>";

            EmailHelper emailHelper = new EmailHelper(_configuration);
            await emailHelper.SendEmailAsync(new MailRequest { ToEmail = appUser.Email, Subject = "Confirm Email", Body = body });

            return RedirectToAction("Index", "Home");
        }
    }
}
