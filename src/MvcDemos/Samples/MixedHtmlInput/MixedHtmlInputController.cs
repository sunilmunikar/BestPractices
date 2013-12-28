using System.Web.Mvc;
using MvcDemos.ViewModels;


namespace MvcDemos.Controllers
{
    public class MixedHtmlInputController : Controller
    {
        public MixedHtmlInputController()
        {
            HtmlHelper.ClientValidationEnabled = true;
            HtmlHelper.UnobtrusiveJavaScriptEnabled = true;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(GenreEditModel model)
        {
            if (ModelState.IsValid)
                return RedirectToAction("Index");

            return View(model);
        }

    }
}