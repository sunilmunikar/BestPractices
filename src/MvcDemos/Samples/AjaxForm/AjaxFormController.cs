using System.Web.Mvc;
using MvcDemos.ViewModels;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace MvcDemos.Controllers
{
    public class AjaxFormController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(GenreEditModel model)
        {
            Thread.Sleep(10000);
            throw new Exception("exception");

            if (ModelState.IsValid)
            {
                return PartialView("Thanks");
            }
            return PartialView("_Create");
        }

        public ViewResult MockAjaxCall()
        {
            return View();
        }

        private async Task<string> Delay()
        {
            await Task.Delay(5000);

            return Task<string>.CurrentId.ToString();
        }
    }
}