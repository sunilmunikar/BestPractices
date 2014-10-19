using MvcDemos.ActionFilters;
using MvcDemos.Validation.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcDemos.Validation.Controllers
{
    public class ReservationController : ApiController
    {
        [ValidationResponseFilter]
        public HttpResponseMessage Post(Reservation reservation)
        {
            return Request.CreateResponse(HttpStatusCode.OK, reservation);
        }
    }
}