using System;
using System.Collections.Generic;
using AutoMapper;
using Core.Entities;
using Core.Services;
using MvcDemos.ViewModels;
using System.Web.Mvc;
using FluentValidation;
using MvcDemos.Samples.Validation;

namespace MvcDemos.Samples
{
    public class GenreController : ValidationBaseController
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

        [HttpPost]
        public ActionResult GetGenreById(int? id)
        {
            //try
            //{
            //    this._genreService.GetGenre(id.Value);
            //}
            //catch (ValidationException ex)
            //{
            //    MvcValidationExtension.AddModelErrors(this.ModelState, ex);
            //    //return View("Index");
            //}

            //Note : try catch is replaced by using customActionInvoker ValidationExceptionHandlingActionInvoker

            if (ModelState.IsValid)
            {
                this._genreService.GetGenre(id.Value);
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        public JsonResult GetGenre(int? id)
        {
            Genre data = null;
            if (id != null)
                data = this._genreService.GetGenre(id.Value);

            return Json(data, JsonRequestBehavior.AllowGet);
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