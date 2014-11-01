using FluentValidation;
using MvcDemos.ActionFilters;
using MvcDemos.Features.Validation.ActionFilters;
using MvcDemos.Validation.Models;
using System.Collections.Generic;
using System.Linq;
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
            try
            {
                ReservationValidator validator = new ReservationValidator();
                validator.ValidateAndThrow(reservation);

                //do something with reservation
            }
            catch (FluentValidation.ValidationException ex)
            {
                var result = ex.Errors.Select(item => new System.ComponentModel.DataAnnotations.ValidationResult(item.ErrorMessage, new List<string> { item.PropertyName }));

                //foreach (var error in ex.Errors)
                //    this.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);

                return Request.CreateResponse(HttpStatusCode.BadRequest, result);
            }

            return Request.CreateResponse(HttpStatusCode.OK, reservation);
        }
    }

    public class ReservationValidator : AbstractValidator<Reservation>
    {
        public ReservationValidator()
        {
            RuleFor(x => x.DateTime).NotNull().LessThanOrEqualTo(System.DateTime.Today);

            //RuleFor(x => x.DateTime).Must((model, dateTime) =>
            //{
            //    // dateTime is in future
            //    return dateTime >= System.DateTime.Today;
            //});
        }
    }
}