using System.Collections.Generic;
using FakeItEasy;
using FluentAssertions;
using GenericRepository.EntityFramework;
using MvcDemos.Controllers;
using MvcDemos.Models;
using Xunit;

namespace UnitTests.MvcDemos
{
    public class GenreServiceTests
    {
        [Fact]
        public void GetGenres_ShouldGetExpectedResults()
        {
            var genres = new List<Genre>()
                             {
                                 new Genre()
                             };

            var dbSet = new FakeDbSet<Genre>();

            foreach (var genre in genres)
            {
                dbSet.Add(genre);
            }

            var entitiesContext = A.Fake<IEntitiesContext>();
            A.CallTo(() => entitiesContext.Set<Genre>()).Returns(dbSet);


            var repo = new EntityRepository<Genre>(entitiesContext);
            var genreService = new GenreService(repo);

            genreService.Should().NotBeNull();

        }
    }
}
