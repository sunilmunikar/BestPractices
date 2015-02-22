using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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

    public class SettingsViewModel
    {
        public string SettingsJson { get; set; }

        public string AngularModuleName { get; set; }
    }

    public class SettingsDto
    {
        public string WebApiBaseUrl { get; set; }

        public string WebApiVersion { get; set; }

        // ...
    }

    //Ref: http://anthonychu.ca/post/how-to-pass-webconfig-settings-to-angularjs
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

        public ActionResult Settings(string angularModuleName = "app.settings")
        {
            var settings = new SettingsDto
            {
                //get this value from web.config
                WebApiBaseUrl = "/api/reservation/"

                // ...
            };

            var serializerSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var settingsJson = JsonConvert.SerializeObject(settings, Formatting.Indented, serializerSettings);

            var settingsVm = new SettingsViewModel
            {
                SettingsJson = settingsJson,
                AngularModuleName = angularModuleName
            };

            Response.ContentType = "text/javascript";
            return View(settingsVm);
        }
    }
}