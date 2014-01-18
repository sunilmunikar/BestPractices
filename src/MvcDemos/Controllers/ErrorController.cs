using System;
using System.Net;
using System.Web.Mvc;

namespace MvcDemos.Controllers
{
    public class TestErrorViewModel
    {
        public bool IsCustomErrorsEnabled { get; set; }
        public string IsCustomErrorsEnabledText { get; set; }

    }

    public class ErrorController : Controller
    {
        public ActionResult TestError()
        {
            var model = new TestErrorViewModel
            {
                IsCustomErrorsEnabled = ControllerContext.HttpContext.IsCustomErrorEnabled,
                IsCustomErrorsEnabledText = ControllerContext.HttpContext.IsCustomErrorEnabled
                                                ? "The defined custom error view will be rendered."
                                                : "To render the defined custom error, the httpErrors element needs to be set to Custom. eg. <httpErrors errorMode=\"Custom\"/>"
            };
            return View(model);

        }

        public ActionResult NotFound()
        {
            Response.StatusCode = (int)HttpStatusCode.NotFound;
            return View();
        }

        public ActionResult ServerError()
        {
            Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            
            // Todo: Pass the exception into the view model, which you can make.
            //       That's an exercise, dear reader, for -you-.
            //       In case u want to pass it to the view, if you're admin, etc.
            // if (User.IsAdmin) // <-- I just made that up :) U get the idea...
            {
                var exception = Server.GetLastError();
                // etc..
            }

            return View();
        }

        // Shhh .. secret test method .. ooOOooOooOOOooohhhhhhhh
        public ActionResult ThrowError()
        {
            throw new Exception("A test exception for ELMAH");

            //throw new NotImplementedException("Pew ^ Pew");
        }

        public ActionResult Test()
        {
            throw new InvalidOperationException("This is a test of our error handling.");
        }

        [Authorize]
        public ActionResult MustBeAuthorized()
        {
            return Content("If you can see this, then you're authorized.");
        }

        public ActionResult WhatchaTalkinBoutWillis()
        {
            // A 403 shouldn't be handled explicitly in the web.config.
            // Therefore, the defaultRedirect should be used.
            return new HttpStatusCodeResult(405, "What-cha talkin' bout Willis??");
        }

        public ActionResult AjaxThrowsAnError()
        {
            throw new InvalidOperationException("Oh noes - code went boomski. :sad panda:");
        }

    }
}