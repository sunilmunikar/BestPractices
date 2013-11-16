using System.Web.Mvc;
using MvcDemos.ViewModels;

namespace MvcDemos.Controllers
{
    public class AjaxFormController : Controller
    {
        public AjaxFormController()
        {
            HtmlHelper.UnobtrusiveJavaScriptEnabled = true;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(GenreEditModel model)
        {
            if (ModelState.IsValid)
            {
                return PartialView("Thanks");
            }
            return PartialView("_Create");
        }
    }
}