using Core.Dtos;
using Core.Entities;
using Core.Services.Validation;
using GenericRepository.EntityFramework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public sealed class AlbumValidator : Validator<AlbumDto>
    {
        protected override IEnumerable<ValidationResult> Validate(AlbumDto model)
        {
            if (model.Price > 100)
            {
                yield return new ValidationResult("Price", "Price cannot be more than 100");
            }
        }
    }
}
