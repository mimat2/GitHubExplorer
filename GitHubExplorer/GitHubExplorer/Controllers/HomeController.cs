using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GitHubExplorer.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]        
        public JsonResult SearchUsers(string userName)
        {
            ViewBag.Message = userName;
            //GitHubExplorer.Repository.GitHubApi gitHubApi = new Repository.GitHubApi("https://api.github.com/");
            //var users = gitHubApi.GetUsersByLogin(userName);
            var users = MvcApplication.Repository.GetUsersByLogin(userName);


            return Json(users.ToList(), JsonRequestBehavior.AllowGet);

            //return View("Index");
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