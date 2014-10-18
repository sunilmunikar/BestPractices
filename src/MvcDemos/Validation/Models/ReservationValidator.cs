using FluentValidation;

namespace MvcDemos.Validation.Models
{
    public class ReservationValidator : AbstractValidator<Reservation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReservationValidator" /> class.
        /// </summary>
        public ReservationValidator()
        {
            RuleFor(item => item.FirstName)
                .NotEmpty();

            RuleFor(item => item.LastName)
              .NotEmpty();
        }
    }
}