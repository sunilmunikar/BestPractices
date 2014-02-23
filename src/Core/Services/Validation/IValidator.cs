using System.Collections.Generic;

namespace Core.Services.Validation
{
    public interface IValidator
    {
        IEnumerable<ValidationResult> Validate(object model);
    }
}
