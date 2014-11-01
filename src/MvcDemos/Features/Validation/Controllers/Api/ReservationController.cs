using FluentValidation;
using MvcDemos.ActionFilters;
using MvcDemos.ApiCore;
using MvcDemos.Features.Validation.ActionFilters;
using MvcDemos.Validation.Models;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcDemos.Validation.Controllers.Api
{
    [RoutePrefix("api/reservation")]
    public class ReservationController : ApiControllerBase
    {
        [ValidationResponseFilter]
        [CheckModelForNull]
        [HttpPost]
        [Route("validateUserInput")]
        public HttpResponseMessage ValidateUserInput(HttpRequestMessage request,
            [FromBody]Reservation reservation)
        {
            return Request.CreateResponse(HttpStatusCode.OK, reservation);
        }

        [ValidationResponseFilter]
        [HttpPost]
        [Route("validateBusinessRule")]
        public HttpResponseMessage ValidateBusinessRule(HttpRequestMessage request,
            [FromBody] Reservation reservation)
        {
            //try
            //{
            //ReservationValidator validator = new ReservationValidator();
            //validator.ValidateAndThrow(reservation);

            //    //do something with reservation
            //}
            //catch (FluentValidation.ValidationException ex)
            //{
            //    var result = ex.Errors.Select(item => new System.ComponentModel.DataAnnotations.ValidationResult(item.ErrorMessage, new List<string> { item.PropertyName }));

            //    //foreach (var error in ex.Errors)
            //    //    this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

            //    return Request.CreateResponse(HttpStatusCode.BadRequest, result);
            //}

            return GetHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;

                ReservationValidator validator = new ReservationValidator();
                validator.ValidateAndThrow(reservation);

                response = request.CreateResponse(HttpStatusCode.OK, reservation);

                return response;
            });
        }
    }

    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.Date).NotNull().GreaterThan(System.DateTime.Today);

            //RuleFor(x => x.DateTime).Must((model, dateTime) =>
            //{
            //    // dateTime is in future
            //    return dateTime >= System.DateTime.Today;
            //});
        }
    }
}