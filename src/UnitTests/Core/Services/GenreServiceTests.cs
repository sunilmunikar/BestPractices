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
                var failures = new List<ValidationFailure> {failure};
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
    }
}