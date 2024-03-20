using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Store.Infrastructure;
using Store.Models;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Store.Controllers
{
    [Authorize]
    public class RegisterController : Controller
    {

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private readonly IAuthenticationManager _authManager;
        private readonly AppUserManager _userManager;

        public RegisterController(IAuthenticationManager authManager, AppUserManager userManager)
        {
            _authManager = authManager;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    AppUser user = new AppUser { UserName = model.Name, Email = model.Email };
                    IdentityResult result = await _userManager.CreateAsync(user, model.Password);

                    if (result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user.Id, "Users");
                        ClaimsIdentity ident = await _userManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);

                        _authManager.SignOut();
                        _authManager.SignIn(new AuthenticationProperties
                        {
                            IsPersistent = false
                        }, ident);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }
    }
}