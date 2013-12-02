using System;
using MvcDemos.ViewModels;
using System.Web.Mvc;

namespace MvcDemos.Samples.FluentValidation
{
    public class GenreController : Controller
    {
        public GenreController()
        {
            HtmlHelper.ClientValidationEnabled = true;
            HtmlHelper.UnobtrusiveJavaScriptEnabled = true;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new GenreEditModel
            {
                StartDate = DateTime.Now.AddDays(2),
                DateToCompareAgainst = DateTime.Now
            };
            //var model = new GenreEditModel();

            return View(model);
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