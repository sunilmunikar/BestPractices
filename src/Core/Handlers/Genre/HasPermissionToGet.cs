using FluentValidation;
using GenericRepository.EntityFramework;

namespace Core.Handlers
{
    public class HasPermissionToGet : AbstractValidator<Entities.Genre>
    {
        private readonly IEntityRepository<Core.Entities.Genre> _repository;

        public HasPermissionToGet()
        {
            RuleFor(x => x.Id).GreaterThanOrEqualTo(0);
        }

        public HasPermissionToGet(IEntityRepository<Core.Entities.Genre> repository)
        {
            _repository = repository;
            RuleFor(x => x.Id).Must(BeOnTheDatabase);
        }

        private bool BeOnTheDatabase(int entityId)
        {
            var result = _repository.GetSingle(entityId);
            return result != null;
        }
    }
}