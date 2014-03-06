using Core;
using Core.Cqrs.QueryHandler;
using Core.Entities;
using GenericRepository.EntityFramework;
using Ploeh.AutoFixture;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Xunit;
//using FluentAssertions

namespace IntegrationTests.QueryHandler
{
    public class TasksByStatusQueryHandlerTests
    {
        private Fixture _fixture;

        public TasksByStatusQueryHandlerTests()
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
        public void Retrive()
        {
            ReCreateDatabaseForTesting();

            var tasks = _fixture.Build<Task>().With(x => x.IsCompleted, true).CreateMany();

            using (var context = new MusicStoreEntities())
            {
                var handler = new TasksByStatusQueryHandler(new EntityRepository<Task>(context));

                foreach (var task in tasks)
                {
                    context.SetAsAdded<Task>(task);
                }
                context.SaveChanges();

                var result = handler.Retrieve(new TasksByStatusQuery() { IsCompleted = true });
                Assert.Equal(result.Tasks.Count(), 3);
            }
        }
    }
}
