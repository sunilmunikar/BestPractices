using System;
using System.Linq;

namespace Core.Services.Validation
{
    public class ValidationProvider : IValidationProvider
    {
        private Func<Type, IValidator> validatorFactory;

        public ValidationProvider(Func<Type, IValidator> validatorFactory)
        {
            this.validatorFactory = validatorFactory;
        }

        public void Validate(object model)
        {
            var results = validatorFactory(model.GetType()).Validate(model).ToArray();
            if (results.Length > 0) throw new ValidationException(results);
        }
    }
}
