using FluentValidation;
using MvcDemos.Validation.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

namespace MvcDemos.Validation.Models
{
    public class Reservation : IValidatableObject
    {
        private readonly IValidator _validator;

        public DateTime DateTime { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Reservation()
        {
            _validator = new ReservationValidator();
        }

        #region IValidatableObject

        /// <summary>
        /// Determines whether the specified object is valid.
        /// </summary>
        /// <param name="validationContext">The validation context.</param>
        /// <returns>
        /// A collection that holds failed-validation information.
        /// </returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            return _validator.Validate(this).ToValidationResult();
        }

        #endregion IValidatableObject
    }
}