using Core.Command;
using Core.Entities;
using FakeItEasy;
using GenericRepository.EntityFramework;
using Xunit;
using Ploeh.AutoFixture;

namespace UnitTests.Core.Command
{
    public class ChangeTaskStatusCommandHandlerTests
    {
        private readonly IEntityRepository<Task> _db;
        private Fixture _fixture;

        public ChangeTaskStatusCommandHandlerTests()
        {
            _db = A.Fake<IEntityRepository<Task>>();
            _fixture = new Fixture();
        }

        [Fact]
        public void Handle()
        {
            var handler = new ChangeTaskStatusCommandHandler(_db);

            ChangeTaskStatusCommand fixtureCommand = _fixture.Create<ChangeTaskStatusCommand>();

            handler.Handle(fixtureCommand);
        }
    }
}