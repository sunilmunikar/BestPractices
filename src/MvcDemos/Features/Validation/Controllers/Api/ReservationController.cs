using FluentValidation;
using MvcDemos.ActionFilters;
using MvcDemos.Features.Validation.ActionFilters;
using MvcDemos.Validation.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcDemos.Validation.Controllers.Api
{
    public class ReservationController : ApiController
    {
        [ValidationResponseFilter]
        [CheckModelForNull]
        [HttpPost]
        //[Route("api/Reservation/ValidateUserInput")]
        public HttpResponseMessage ValidateUserInput(Reservation reservation)
        {
            return Request.CreateResponse(HttpStatusCode.OK, reservation);
        }

        // ToDo@Sunil: above post only works when validateBusinessRule is commented
        [ValidationResponseFilter]
        [HttpPost]
        [Route("api/Reservation/ValidateBusinessRule")]
        public HttpResponseMessage ValidateBusinessRule(Reservation reservation)
        {
            ReservationValidator validator = new ReservationValidator();
            validator.ValidateAndThrow(reservation);

            return Request.CreateResponse(HttpStatusCode.OK, reservation);
        }
    }

    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.DateTime).Must((model, dateTime) =>
            {
                // dateTime is in future
                return dateTime >= System.DateTime.Today;
            });
        }
    }
}