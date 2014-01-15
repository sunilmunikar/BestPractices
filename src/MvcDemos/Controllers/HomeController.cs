using MvcDemos.Models;
using System.Web.Mvc;

namespace MvcDemos.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult AnonymouslyVisible()
        {
            return View();
        }

    }
}
