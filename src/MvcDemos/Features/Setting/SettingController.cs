using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemos.Features.Setting
{
    public class SettingViewModel
    {
        public bool IsDebug { get; set; }
    }

    public class SettingController : Controller
    {
        public ActionResult Index()
        {
            var settingVM = new SettingViewModel()
            {
                IsDebug = true
            };

            return View(settingVM);
        }
    }
}