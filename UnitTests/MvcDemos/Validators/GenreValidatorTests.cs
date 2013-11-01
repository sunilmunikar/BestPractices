using FluentValidation.TestHelper;
using MvcDemos.Validators;
using MvcDemos.ViewModels;
using Ploeh.AutoFixture;
using Xunit;

namespace UnitTests.MvcDemos.Validators
{
    public class GenreValidatorTests
    {
        private readonly GenreValidator _validator;
        private readonly Fixture _fixtue;

        public GenreValidatorTests()
        {
            _fixtue = new Fixture();
            _validator = new GenreValidator();
        }

        [Fact]
        public void NameIsNull_ReturnsError()
        {
            var editModel = _fixtue.Build<GenreEditModel>()
                                   .With(x => x.Name, null)
                                   .Create();

            _validator.ShouldHaveValidationErrorFor(x => x.Name, editModel);
        }

        [Fact]
        public void NameIsNotNull_ReturnsNoError()
        {
            var editModel = _fixtue.Build<GenreEditModel>().Create();

            _validator.ShouldNotHaveValidationErrorFor(x => x.Name, editModel);
        }
    }
}