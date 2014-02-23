using Core.Dtos;
using Core.Services;
using Core.Services.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemos.Samples
{
    public class ValidationController : Controller
    {
        private IAlbumService _albumService;

        public ValidationController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(AlbumDto albumToCreate)
        {
            try
            {
                _albumService.CreateAlbum(new AlbumDto() { Price = 101 });
            }
            catch (ValidationException ex)
            {
                MvcValidationExtension.AddModelErrors(this.ModelState, ex);
                return View();
            }

            return RedirectToAction("Index");
        }

    }

}
