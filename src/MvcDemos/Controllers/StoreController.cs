using Core.Entities;
using Core.Services;
using GenericRepository.EntityFramework;
using MvcDemos.Models;
using System.Web.Mvc;

namespace MvcDemos.Controllers
{
    public class StoreController : Controller
    {
        //private MusicStoreEntities db = new MusicStoreEntities();
        private readonly IGenreService _genreService;

        public StoreController()
            : this(new GenreService(new EntityRepository<Genre>(new MusicStoreEntities())))
        {
            HtmlHelper.UnobtrusiveJavaScriptEnabled = true;
        }

        public StoreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public ActionResult Index()
        {
            //var genres = db.Genres.ToList();
            var genres = _genreService.GetGenres();
            return View(genres);
        }

        public PartialViewResult CreatePartial()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                _genreService.Add(genre);

                return PartialView("Thanks");
            }

            return PartialView("_Create", genre);
        }

        ////
        //// GET: /Store/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Genre genre = _genreService.GetGenre(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Create", genre);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(genre).State = EntityState.Modified;
                //db.SaveChanges();
                _genreService.Update(genre);

                return PartialView("Thanks");
            }
            return PartialView("_Create", genre);
        }

        ////
        //// POST: /Store/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Genre genre = db.Genres.Find(id);
            //db.Genres.Remove(genre);
            //db.SaveChanges();
            _genreService.Delete(id);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    db.Dispose();
        //    base.Dispose(disposing);
        //}
    }
}