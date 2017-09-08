using GitHubExplorer.Models;
using GitHubExplorer.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GitHubExplorer.Controllers
{
    [RequireHttps]
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult FindUser(string userName)
        {
            LogHelper.LogInfo($"User {HttpContext.User.Identity.Name} called FindUser method with parameter: {userName}");
            var userDto = MvcApplication.Repository.GetUserWithReposByLogin(userName);
            return Json(userDto, JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}