using System;
using System.Collections.Generic;
using Core.Services;
using MvcDemos.ViewModels;
using System.Web.Mvc;
using CoreLayer = Core.Entities;

namespace MvcDemos.Samples.FluentValidation
{
    public class GenreController : Controller
    {
        private readonly IGenreService genreService;

        public GenreController(IGenreService genreService)
        {
            HtmlHelper.ClientValidationEnabled = true;
            HtmlHelper.UnobtrusiveJavaScriptEnabled = true;

            this.genreService = genreService;
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

            var genre = new CoreLayer.Genre { Name = model.Name, Description = model.Description };

            genreService.Add(genre);

            return View(model);
        }

        public JsonResult GetGenre(int? id)
        {
            this.genreService.GetGenre(id.Value);

            IEnumerable<CoreLayer.Genre> data = new CoreLayer.Genre[0];
            return Json(data);
        }
    }
}