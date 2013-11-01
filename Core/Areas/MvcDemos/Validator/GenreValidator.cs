using FluentValidation;
using MvcDemos.ViewModels;

namespace MvcDemos.Validator
{
    public class GenreValidator : AbstractValidator<GenreEditModel>
    {
        public GenreValidator()
        {
            RuleFor(x => x.Name).NotNull();
        }
    }
}