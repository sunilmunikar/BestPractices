using Core.Dtos;
using Core.Services;
using Core.Services.Validation;
using MvcDemos.Samples.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemos.Samples
{
    public class ValidationController : Controller
    {
        protected override IActionInvoker CreateActionInvoker()
        {
            return new MyCustomValidationExceptionHandlingActionInvoker();
        }

        private IAlbumService _albumService;

        public ValidationController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public ActionResult Index()
        {
            var model = new AlbumDto() { Price = 101 };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(AlbumDto albumToCreate)
        {
            //try
            //{
            //    _albumService.CreateAlbum(new AlbumDto() { Price = 101 });
            //}
            //catch (ValidationException ex)
            //{
            //    this.ModelState.AddModelErrors(ex);
            //    return View();
            //}

            if (ModelState.IsValid)
            {
                _albumService.CreateAlbum(albumToCreate);
                return RedirectToAction("Index");
            }

            return View(albumToCreate);
        }

    }

}
