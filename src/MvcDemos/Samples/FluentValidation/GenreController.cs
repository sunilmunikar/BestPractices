using System;
using System.Collections.Generic;
using AutoMapper;
using Core.Entities;
using Core.Services;
using MvcDemos.ViewModels;
using System.Web.Mvc;

namespace MvcDemos.Samples.FluentValidation
{
    public class GenreController : Controller
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            HtmlHelper.ClientValidationEnabled = true;
            HtmlHelper.UnobtrusiveJavaScriptEnabled = true;

            this._genreService = genreService;
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
        [ValidateAntiForgeryToken]
        public ActionResult Create(GenreEditModel model)
        {
            if (ModelState.IsValid)
                return RedirectToAction("Index");

            var genre = new Genre { Name = model.Name, Description = model.Description };

            _genreService.Add(genre);

            return View(model);
        }

        public JsonResult GetGenre(int? id)
        {
            if (id != null)
                this._genreService.GetGenre(id.Value);

            IEnumerable<Genre> data = new Genre[0];
            return Json(data);
        }

        public ActionResult Edit(int id = 0)
        {
            var genre = _genreService.GetGenre(id);
            if (genre == null)
                return HttpNotFound();

            var model = new GenreEditModel()
                            {
                                Id = genre.Id,
                                Name = genre.Name,
                                Description = genre.Description
                            };

            return View("Create", model);
        }
    }
}