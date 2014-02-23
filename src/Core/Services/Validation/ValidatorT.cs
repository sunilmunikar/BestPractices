using System.Collections.Generic;

namespace Core.Services.Validation
{
    public abstract class Validator<T> : IValidator
    {
        public IEnumerable<ValidationResult> Validate(object model)
        {
            return this.Validate((T)model);
        }

        protected abstract IEnumerable<ValidationResult> Validate(T model);
    }
}
