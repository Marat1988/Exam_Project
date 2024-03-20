using Microsoft.AspNet.Identity;
using Store.Infrastructure;
using Store.Models;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Store.Api
{
    [Authorize(Roles = "Administrators")]
    public class AdminApiController: Controller
    {
        private readonly AppUserManager _userManager;

        public AdminApiController(AppUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<string> LockoutEnabled(string userId, bool LockoutEnabled)
        {
            try
            {
                AppUser user = await _userManager.FindByIdAsync(userId);
                user.LockoutEnabled = LockoutEnabled;
                if (user != null)
                {
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    return result.Succeeded ? "Успешно" : "Ошибка";
                }
                else
                {
                    return "Пользователь не найден";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
    }
}