using Core;
using Core.Command;
using Core.Entities;
using GenericRepository.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Xunit;
using Ploeh.AutoFixture;

namespace IntegrationTests.CommandHandler
{
    public class ChangeTaskStatusCommandHandlerTests
    {
        private Fixture _fixture;

        public ChangeTaskStatusCommandHandlerTests()
        {
            _fixture = new Fixture();
        }

        private void ReCreateDatabaseForTesting()
        {
            Database.SetInitializer(new DatabaseSeedingInitializer());
            using (var context = new MusicStoreEntities())
            {
                context.Database.Initialize(true);
            }
        }

        [Fact]
        public void Handle()
        {
            ReCreateDatabaseForTesting();

            using (var context = new MusicStoreEntities())
            {
                var handler = new ChangeTaskStatusCommandHandler(new EntityRepository<Task>(context));

                var command = _fixture.Create<ChangeTaskStatusCommand>();

                handler.Handle(command);
            }
        }
    }
}
