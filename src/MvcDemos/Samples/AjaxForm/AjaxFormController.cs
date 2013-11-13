using Core.Entities;
using System.Web.Mvc;

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
        public ActionResult Index(Account model)
        {
            if (ModelState.IsValid)
            {
                return PartialView("Thanks");
            }
            return PartialView("_Create");
        }
    }
}