using FluentValidation;

namespace Core.Handlers.Genre
{
    public class CanBeAdded : AbstractValidator<Entities.Genre>
    {
        public CanBeAdded()
        {
            RuleFor(x => x.Id).NotNull();
        }
    }   
}