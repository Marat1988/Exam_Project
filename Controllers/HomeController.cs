﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Store.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View(GetData("Index"));
        }

        [Authorize(Roles = "Users")]
        public ActionResult OtherAction()
        {
            return View("Index", GetData("OtherAction"));
        }

        private Dictionary<string, object> GetData(string actionName)
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();

            dict.Add("Action", actionName);
            dict.Add("Пользователь", HttpContext.User.Identity.Name);
            dict.Add("Аутентифицирован?", HttpContext.User.Identity.IsAuthenticated);
            dict.Add("Тип аутентификации", HttpContext.User.Identity.AuthenticationType);
            dict.Add("В роли Users?", HttpContext.User.IsInRole("Users"));

            return dict;
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}