using Core.Entities;
using MvcDemos.Models;
using System.Data.Entity;

namespace IntegrationTests
{
    public class DatabaseSeedingInitializer : DropCreateDatabaseAlways<MusicStoreEntities>
    {
        protected override void Seed(MusicStoreEntities context)
        {
            var genre = new Genre { Name = "Genre 1" };
            context.Genres.Add(genre);
        }
    }
}
