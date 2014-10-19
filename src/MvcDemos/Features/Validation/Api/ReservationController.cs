using FluentValidation;
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
        [HttpPost]
        [Route("Reservation/ValidateUserInput")]
        public HttpResponseMessage ValidateUserInput(Reservation reservation)
        {
            return Request.CreateResponse(HttpStatusCode.OK, reservation);
        }

        // ToDo@Sunil: above post only works when validateBusinessRule is commented
        //[ValidationResponseFilter]
        //[HttpPost]
        //[Route("Reservation/ValidateBusinessRule")]
        //public HttpResponseMessage ValidateBusinessRule(Reservation reservation)
        //{
        //    ReservationValidator validator = new ReservationValidator();
        //    validator.ValidateAndThrow(reservation);

        //    return Request.CreateResponse(HttpStatusCode.OK, reservation);
        //}
    }

    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(r => r.FirstName).NotEqual("Sunil");
        }
    }
}