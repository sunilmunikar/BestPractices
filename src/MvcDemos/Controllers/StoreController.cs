using System.Data;
using System.Linq;
using System.Web.Mvc;
using MvcDemos.Models;

namespace MvcDemos.Controllers
{
    public class StoreController : Controller
    {
        private MusicStoreEntities db = new MusicStoreEntities();

        public StoreController()
        {
            HtmlHelper.UnobtrusiveJavaScriptEnabled = true;
        }

        //
        // GET: /Store/

        public ActionResult Index()
        {
            return View(db.Genres.ToList());
        }

        public PartialViewResult CreatePartial()
        {
            return PartialView("_Create");
        }

        //
        // POST: /Store/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Genres.Add(genre);
                db.SaveChanges();
                return PartialView("Thanks");
            }

            return PartialView("_Create", genre);
        }

        //
        // GET: /Store/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Genre genre = db.Genres.Find(id);
            if (genre == null)
            {
                return HttpNotFound();
            }
            return PartialView("_Create", genre);
        }

        //
        // POST: /Store/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Genre genre)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genre).State = EntityState.Modified;
                db.SaveChanges();
                return PartialView("Thanks");
            }
            return PartialView("_Create", genre);
        }

        //
        // POST: /Store/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Genre genre = db.Genres.Find(id);
            db.Genres.Remove(genre);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}