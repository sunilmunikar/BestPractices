using MvcDemos.ViewModels;
using System.Web.Mvc;

namespace MvcDemos.Samples.FluentValidation
{
    public class GenreController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GenreEditModel model)
        {
            if (ModelState.IsValid)
                return RedirectToAction("Index");

            return View(model);
        }
    }
}