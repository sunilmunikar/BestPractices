using System.Web.Mvc;

namespace MvcDemos.Samples
{
    public static class MvcValidationExtension
    {
        public static void AddModelErrors(this ModelStateDictionary state,
            Core.Services.Validation.ValidationException exception)
        {
            foreach (var error in exception.Errors)
                state.AddModelError(error.Key, error.Message);
        }

        public static void AddModelErrors(this ModelStateDictionary state,
            FluentValidation.ValidationException exception)
        {
            foreach (var error in exception.Errors)
                state.AddModelError(error.PropertyName, error.ErrorMessage);
        }

    }
}
