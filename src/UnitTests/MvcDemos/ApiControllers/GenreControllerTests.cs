using System.Diagnostics;
using Core.Entities;
using Core.Services;
using FakeItEasy;
using FluentAssertions;
using MvcDemos.ApiControllers;
using Xunit;

namespace UnitTests.MvcDemos.ApiControllers
{
    public class GenreControllerTests
    {
        [Fact]
        public void Get_ReturnsValue()
        {
            var fakeGenereService = A.Fake<IGenreService>();
            A.CallTo(() => fakeGenereService.GetGenre(A<int>.Ignored)).Returns(new Genre());

            var api = new GenreController(fakeGenereService);
            var result = api.Get();
            result.Should().NotBeNull();
        } 
    }
}