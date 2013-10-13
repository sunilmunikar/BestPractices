using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemos.Controllers
{
    public class ResourcesController : Controller
    {
        //
        // GET: /Resources/

        public ActionResult Index()
        {
            string name = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
            return View();
        }

    }
}
