using Core;
using System.Data.Entity;
using Xunit;

namespace IntegrationTests
{
    public class InitializeEFTests
    {
        private void ReCreateDatabaseForTesting()
        {
            Database.SetInitializer(new DatabaseSeedingInitializer());
            using (var context = new MvcDemosEntities())
            {
                context.Database.Initialize(true);
            }
        }

        [Fact]
        public void Initialize()
        {
            ReCreateDatabaseForTesting();
        }
    }
}
