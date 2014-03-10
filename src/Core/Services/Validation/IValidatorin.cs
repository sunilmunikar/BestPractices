using Core.Command;
using System.Collections.Generic;

namespace Core.Services.Validation
{
    public interface IValidator<in TCommand> where TCommand : ICommand
    {
        IEnumerable<ValidationResult> Validate(TCommand model);
    }
}