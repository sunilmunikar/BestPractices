using System.Web.Mvc;

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
