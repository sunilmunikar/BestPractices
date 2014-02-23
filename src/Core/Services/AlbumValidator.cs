using Core.Dtos;
using Core.Services.Validation;
using System.Collections.Generic;

namespace Core.Services
{
    public sealed class AlbumValidator : Validator<AlbumDto>
    {
        public AlbumValidator()
        {

        }
        protected override IEnumerable<ValidationResult> Validate(AlbumDto model)
        {
            if (model.Price > 100)
            {
                yield return new ValidationResult("Price", "Price cannot be more than 100");
            }
        }
    }
}
