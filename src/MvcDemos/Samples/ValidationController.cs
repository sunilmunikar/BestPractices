using Core.Dtos;
using Core.Services;
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

        public ValidationController()
        {
            //_albumService = new AlbumService()
        }

        public ValidationController(IAlbumService albumService)
        {
            _albumService = albumService;
        }
        //
        // GET: /Validation/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index(AlbumDto albumToCreate)
        {
            //if (!_albumService.CreateAlbum(albumToCreate))
            //    return View();

            return RedirectToAction("Index");
        }

    }

}
