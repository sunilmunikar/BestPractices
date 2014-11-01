using System.Web.Mvc;

//Note : make sure that the namespace is on top level of folder. 
// mvc controller namespace is used to look for views
namespace MvcDemos.Features.Validation
{
    public class ReservationController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}
