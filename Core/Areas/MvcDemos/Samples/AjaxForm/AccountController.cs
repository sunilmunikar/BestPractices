using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcDemos.Models;

namespace MvcDemos.Controllers
{
    public class AjaxFormController : Controller
    {
        public AjaxFormController()
        {
            HtmlHelper.UnobtrusiveJavaScriptEnabled = true;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Account model)
        {
            if (ModelState.IsValid)
            {
                return PartialView("Thanks");
            }
            return PartialView("_Create");
        }
    }
}