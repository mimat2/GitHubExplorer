using GitHubExplorer.Shared.Interfaces;
using System.Web.Mvc;

namespace GitHubExplorer.Controllers
{
    [RequireHttps]
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUsersRepository _repository;
        private readonly ILogger _logger;

        public HomeController(IUsersRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult FindUser(string userName)
        {
            _logger.LogInfo($"User {HttpContext.User.Identity.Name} called FindUser method with parameter: {userName}");
            var userDto = _repository.GetUserWithReposByLogin(userName);
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