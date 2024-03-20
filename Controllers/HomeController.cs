using Microsoft.AspNet.Identity;
using Microsoft.Owin.Logging;
using Microsoft.Owin.Security;
using Store.Infrastructure;
using Store.Models;
using Store.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Store.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IAuthenticationManager _authManager;
        private readonly AppUserManager _userManager;

        public HomeController(IAuthenticationManager authManager, AppUserManager userManager)
        {
            _authManager = authManager;
            _userManager = userManager;
        }

        /*private Dictionary<string, object> GetData(string actionName)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("Action", actionName);
            dict.Add("Пользователь", HttpContext.User.Identity.Name);
            dict.Add("Аутентифицирован?", HttpContext.User.Identity.IsAuthenticated);
            dict.Add("Тип аутентификации", HttpContext.User.Identity.AuthenticationType);
            dict.Add("В роли Users?", HttpContext.User.IsInRole("Users"));

            return dict;
        }*/

        [Authorize]
        public ActionResult Index()
        {
            AppUser user = _userManager.Users.FirstOrDefault(item => item.UserName == HttpContext.User.Identity.Name);
            string name = user.UserName;
            ProfileUserViewModel profileUserViewModel = new ProfileUserViewModel()
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Patronymic = user.Patronymic,
                DateBirthDay = (user.DateBirthDay == null) ? DateTime.Now.Date : user.DateBirthDay,
                Photo = user.Photo,
                Password = ""
            };
            return View(profileUserViewModel);
        }
        [AllowAnonymous]
        public ActionResult About()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Contact()
        {
            return View();
        }

    }
}