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
            validatorFactory(model.GetType())
                .Validate(model).ToArray();
        }
    }
}
