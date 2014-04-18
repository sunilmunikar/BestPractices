using MvcDemos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemos.Samples.EnumsTemplates
{
    public class MovieGenreController : Controller
    {
        //
        // GET: /MovieGenre/

        public ActionResult Index()
        {
            var movie = new Movie();
            movie.Genre = MovieGenre.Adventure;
            movie.Title = "Gravity";

            return View(movie);
        }

    }
}
