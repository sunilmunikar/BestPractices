#region namespace

using System;
using System.Collections.Generic;
using AutoMapper;
using Core.Entities;
using Core.Handlers;
using Core.Services;
using FakeItEasy;
using FluentAssertions;
using FluentValidation.Results;
using GenericRepository.EntityFramework;
using Xunit;
using FluentValidation;
using System.Linq;
using Core.Dtos;
using Ploeh.AutoFixture;

#endregion

namespace UnitTests.Core.Services
{
    public class GenreServiceTests
    {
        public class GetGenre
        {
            [Fact]
            public void GivenAValidId_ReturnsGenre()
            {
                const int aValidId = 1;
                var genres = new List<Genre>
                                 {
                                     new Genre
                                         {
                                             Id = aValidId
                                         }
                                 };
                var dbSet = new FakeDbSet<Genre>();
                genres.ForEach(genre => dbSet.Add(genre));

                var entitiesContext = A.Fake<IEntitiesContext>();
                A.CallTo(() => entitiesContext.Set<Genre>()).Returns(dbSet);

                var fakeValidator = A.Fake<IValidator>();
                var failure = new ValidationFailure("Id", "error");
                var failures = new List<ValidationFailure> { failure };
                A.CallTo(() => fakeValidator.Validate(A<Genre>.Ignored)).Returns(new ValidationResult(failures));

                IValidatorFactory factory = A.Fake<IValidatorFactory>();
                //var hasPermissionToGet = new HasPermissionToGet(fakeRepo);

                //A.CallTo(() => factory.GetValidator<HasPermissionToGet>()).Returns<HasPermissionToGet>(hasPermissionToGet as IValidator<HasPermissionToGet>);

                var fakeMapping = A.Fake<IMappingEngine>();

                var repo = new EntityRepository<Genre>(entitiesContext);
                var genreService = new GenreService(repo, factory, fakeMapping);

                Genre result = genreService.GetGenre(aValidId);

                result.Should().NotBeNull();
            }

            [Fact]
            public void GiveAIdWhichUserHasNoPermission_ShouldThrowException()
            {
                const int aValidId = 1;
                var genres = new List<Genre>
                                 {
                                     new Genre
                                         {
                                             Id = aValidId
                                         }
                                 };

                var dbSet = new FakeDbSet<Genre>();

                foreach (Genre genre in genres)
                {
                    dbSet.Add(genre);
                }

                var entitiesContext = A.Fake<IEntitiesContext>();
                A.CallTo(() => entitiesContext.Set<Genre>()).Returns(dbSet);

                var fakeValidator = A.Fake<IValidator<Genre>>();
                var validationFailure = new List<ValidationFailure> { new ValidationFailure("Id", "fake error") };
                var validationResult = new ValidationResult(validationFailure);

                A.CallTo(() => fakeValidator.Validate(A<Genre>.Ignored)).Returns(validationResult);

                var repo = new EntityRepository<Genre>(entitiesContext);
                IValidatorFactory factory = A.Fake<IValidatorFactory>();
                var fakeMapping = A.Fake<IMappingEngine>();
                var genreService = new GenreService(repo, factory, fakeMapping);

                //Genre result = genreService.GetGenre(aValidId);

                Action act = () => genreService.GetGenre(aValidId);

                act.ShouldThrow<ValidationException>();
            }
        }

        public class GetGenreDtos
        {
            private IEntityRepository<Genre> _genreRepository;
            private IMappingEngine _mapper;

            private Fixture _fixture;

            public GetGenreDtos()
            {
                _fixture = new Fixture();
                _fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => _fixture.Behaviors.Remove(b));

                _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            }

            [Fact]
            public void ShouldCallRepositoryOnce()
            {
                var genres = new List<Genre>().AsQueryable();

                _genreRepository = A.Fake<IEntityRepository<Genre>>();
                A.CallTo(() => _genreRepository.GetAll()).Returns(genres);

                var sut = new GenreServiceBuilder()
                    .WithFakeGenreRepository(_genreRepository)
                    .WithDefaultFakeValidator()
                    .Build();

                var result = sut.GetGenreDtos();

                A.CallTo(() => _genreRepository.GetAll()).MustHaveHappened(Repeated.Exactly.Once);
            }

            [Fact]
            public void GetAllAvailableGenre()
            {
                var genres = new List<Genre>().AsQueryable();

                _genreRepository = A.Fake<IEntityRepository<Genre>>();
                A.CallTo(() => _genreRepository.GetAll()).Returns(genres);

                var sut = new GenreServiceBuilder()
                    .WithFakeGenreRepository(_genreRepository)
                    .WithDefaultFakeValidator()
                    .Build();

                var result = sut.GetGenreDtos();

                result.Should().NotBeNull();
            }

            [Fact]
            public void WhenGetOneGenreFromRepo_ShouldReturnOneGenreDto()
            {
                var genres = _fixture.CreateMany<Genre>(1).ToList();

                _genreRepository = A.Fake<IEntityRepository<Genre>>();
                A.CallTo(() => _genreRepository.GetAll()).Returns(genres.AsQueryable());


                _mapper = A.Fake<IMappingEngine>();

                var sut = new GenreServiceBuilder()
                    .WithFakeGenreRepository(_genreRepository)
                    .WithDefaultFakeValidator()
                    .WithDefaultFakeMapper()
                    .Build();

                IEnumerable<GenreDto> genreDtos = sut.GetGenreDtos();
                genreDtos.Count().Should().Be(genres.Count);
                genreDtos.ShouldBeEquivalentTo(genres, option => option.ExcludingMissingProperties());
            }

            [Fact]
            public void WhenGetGenreFromRepo_ShouldCallMapper()
            {
                var genres = _fixture.CreateMany<Genre>().ToList();
                _genreRepository = A.Fake<IEntityRepository<Genre>>();
                A.CallTo(() => _genreRepository.GetAll()).Returns(genres.AsQueryable());

                _mapper = A.Fake<IMappingEngine>();
                A.CallTo(() => _mapper.Map<Genre, GenreDto>(A<Genre>.Ignored)).Returns(A<GenreDto>.Ignored);

                var sut = new GenreServiceBuilder()
                    .WithFakeGenreRepository(_genreRepository)
                    .WithDefaultFakeValidator()
                    .WithFakeMapper(_mapper)
                    .Build();

                IEnumerable<GenreDto> genreDtos = sut.GetGenreDtos();

                foreach (var genre in genres)
                {
                    A.CallTo(() => _mapper.Map<Genre, GenreDto>(genre)).MustHaveHappened(Repeated.Exactly.Once);
                }
            }
        }
    }
}