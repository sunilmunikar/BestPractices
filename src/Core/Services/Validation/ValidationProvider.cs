using System;
using System.Linq;

namespace Core.Services.Validation
{
    public class ValidationProvider : IValidationProvider
    {
        private Func<Type, IValidator> _validatorFactory;

        public ValidationProvider(Func<Type, IValidator> validatorFactory)
        {
            _validatorFactory = validatorFactory;
        }

        public void Validate(object model)
        {
            IValidator validator = _validatorFactory(model.GetType());
            var results = validator.Validate(model).ToArray();

            if (results.Length > 0) throw new ValidationException(results);
        }
    }
}