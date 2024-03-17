using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Store.Infrastructure;
using Store.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Store.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly IAuthenticationManager _authManager;
        private readonly AppUserManager _userManager;

        public AccountController(IAuthenticationManager authManager, AppUserManager userManager)
        {
            _authManager = authManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                return View("Error", new string[] { "В доступе отказано" });
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel details)
        {
            AppUser user = await _userManager.FindAsync(details.Name, details.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Некорректное имя или пароль.");
            }
            else
            {
                ClaimsIdentity ident = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

                _authManager.SignOut();
                _authManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = false
                }, ident);
                return RedirectToAction("Index", "Home");
            }

            return View(details);
        }

        [Authorize]
        public ActionResult Logout()
        {
            _authManager.SignOut();
            return RedirectToAction("Login", "Account");
        }
    }
}