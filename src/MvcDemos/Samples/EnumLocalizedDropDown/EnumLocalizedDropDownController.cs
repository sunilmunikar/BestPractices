using MvcDemos.Helpers;
using MvcDemos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace MvcDemos.Samples.EnumsTemplates
{
    public class EnumLocalizedDropDownController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "EnumDropDownList demo";

            var newEvent = new WeeklyEvent()
            {
                Day = WeekDay.Wednesday,
                AnotherDay = WeekDay.Friday,
                Title = "Demo event"
            };

            return View(newEvent);
        }
    }
}
