using MvcDemos.Models;
using My.Framework.Web.MvcSecurity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemos.Controllers
{
    public class ParameterTamperingController : Controller
    {
        private MvcApplication3Context db = new MvcApplication3Context();

        //
        // GET: /ParameterTampering/

        public ActionResult Index()
        {
            return View(db.GenreModels.ToList());
        }

        //
        // GET: /ParameterTampering/Details/5

        public ActionResult Details(int id = 0)
        {
            GenreModel genremodel = db.GenreModels.Find(id);
            if (genremodel == null)
            {
                return HttpNotFound();
            }
            return View(genremodel);
        }

        //
        // GET: /ParameterTampering/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /ParameterTampering/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GenreModel genremodel)
        {
            if (ModelState.IsValid)
            {
                db.GenreModels.Add(genremodel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(genremodel);
        }

        //
        // GET: /ParameterTampering/Edit/5

        public ActionResult Edit(int id = 0)
        {
            GenreModel genremodel = db.GenreModels.Find(id);
            if (genremodel == null)
            {
                return HttpNotFound();
            }
            return View(genremodel);
        }

        //
        // POST: /ParameterTampering/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateAntiModelInjectionAttribute("Id")]
        public ActionResult Edit(GenreModel genremodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(genremodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(genremodel);
        }

        //
        // GET: /ParameterTampering/Delete/5

        public ActionResult Delete(int id = 0)
        {
            GenreModel genremodel = db.GenreModels.Find(id);
            if (genremodel == null)
            {
                return HttpNotFound();
            }
            return View(genremodel);
        }

        //
        // POST: /ParameterTampering/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GenreModel genremodel = db.GenreModels.Find(id);
            db.GenreModels.Remove(genremodel);
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