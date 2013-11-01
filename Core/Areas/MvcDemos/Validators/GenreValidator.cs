using FluentValidation;
using MvcDemos.ViewModels;

namespace MvcDemos.Validators
{
    public class GenreValidator : AbstractValidator<GenreEditModel>
    {
        public GenreValidator()
        {
            RuleFor(x => x.Name).NotNull();
        }
    }
}