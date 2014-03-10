using Core.Command;
using Core.Entities;
using Core.Services.Validation;
using FakeItEasy;
using GenericRepository.EntityFramework;
using Ploeh.AutoFixture;
using Xunit;

namespace UnitTests.Core.Services
{
    public class ChangeTaskStatusValidationCommandHandlerDecorator
    {
        private IEntityRepository<Task> _db;
        private Fixture _fixture;

        public ChangeTaskStatusValidationCommandHandlerDecorator()
        {
            _db = A.Fake<IEntityRepository<Task>>();
            _fixture = new Fixture();
        }

        [Fact]
        public void Handle()
        {
            ICommandHandler<ChangeTaskStatusCommand> handler = new ChangeTaskStatusCommandHandler(_db);
            IValidator<ChangeTaskStatusCommand> validator = new ChangeTaskStatusCommandValidator(_db);

            var decorator = new ValidationCommandHandlerDecorator<ChangeTaskStatusCommand>(
                handler, validator);

            ChangeTaskStatusCommand fixtureCommand = _fixture.Create<ChangeTaskStatusCommand>();

            decorator.Handle(fixtureCommand);
        }
    }
}
