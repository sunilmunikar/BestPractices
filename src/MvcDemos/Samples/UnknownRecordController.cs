using Core.Services;
using MvcDemos.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemos.Samples
{
    public class UnknownRecordController : Controller
    {
        private readonly IGenreService _genreService;

        public UnknownRecordController(IGenreService genreService)
        {
            this._genreService = genreService;

        }

        [HandleRecordNotFound]
        public ActionResult Index()
        {
            const int unexistingGenereId = -1;
            var unKnownRecord = _genreService.GetGenre(unexistingGenereId);

            return View(unKnownRecord);
        }

    }
}
