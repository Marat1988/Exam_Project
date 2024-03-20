using Microsoft.AspNet.Identity;
using Store.Infrastructure;
using Store.Models;
using Store.ViewModel;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Store.Api
{
    [Authorize]
    public class ProfileApiController: Controller
    {
        private readonly AppUserManager _userManager;

        public ProfileApiController(AppUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<string> UpdateProfileUser(ProfileUserViewModel viewModel)
        {
            try
            {
                AppUser user = await _userManager.FindByIdAsync(viewModel.Id);
                user.FirstName = viewModel.FirstName;
                user.LastName = viewModel.LastName;
                user.Patronymic = viewModel.Patronymic;
                user.DateBirthDay = viewModel.DateBirthDay;
                if (viewModel.Password != null)
                {
                    IdentityResult validPass = await _userManager.PasswordValidator.ValidateAsync(viewModel.Password);
                    if (validPass.Succeeded)
                    {
                        user.PasswordHash = _userManager.PasswordHasher.HashPassword(viewModel.Password);
                    }
                    else
                    {
                        return validPass.Errors.Single();
                    }
                }
                IdentityResult result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    return "Ошибка во время обновления профиля пользователя";
                }
                return "Успешное обновление профиля пользователя";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> UploadAvatar(HttpPostedFileBase uploadImage)
        {
            if (uploadImage != null)
            {
                AppUser user = await _userManager.FindByIdAsync(HttpContext.User.Identity.GetUserId());
                using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                {
                    byte[] imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    user.Photo = imageData;
                    await _userManager.UpdateAsync(user);
                }        
            }
            return RedirectToAction("Index","Home");
        }

        [HttpPost]
        [Authorize]
        public async Task<string> DeleteAvatar()
        {
            try
            {
                AppUser user = await _userManager.FindByIdAsync(HttpContext.User.Identity.GetUserId());
                user.Photo = null;
                await _userManager.UpdateAsync(user);
                return "Удаление завершено";
            }
            catch (Exception ex)
            {
                return "Ошибка при удалении " + ex.Message;
            }
        }
    }
}