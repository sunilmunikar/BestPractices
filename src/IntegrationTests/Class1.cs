using MvcDemos.Models;
using System.Data.Entity;
using Xunit;

namespace IntegrationTests
{
    public class Class1
    {
        private void ReCreateDatabaseForTesting()
        {
            Database.SetInitializer(new DatabaseSeedingInitializer());
            using (var context = new MusicStoreEntities())
            {
                context.Database.Initialize(true);
            }
        }

        [Fact]
        public void InitializeEfTest()
        {
            ReCreateDatabaseForTesting();
        }
    }
}
