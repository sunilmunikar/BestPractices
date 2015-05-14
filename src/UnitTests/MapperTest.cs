using FakeItEasy;
using System;
using System.Collections.Generic;
using Xunit;

namespace UnitTests
{
    public class Person
    {
        public string Name { get; set; }
    }

    public class PersonDto
    {
        public string Name { get; set; }
    }

    public abstract class MapperBase
    {
        protected static TOutput Map<TInput, TOutput>(TInput input, Func<TInput, TOutput> action)
            where TInput : class
            where TOutput : class
        {
            try
            {
                if (input == null)
                {
                    return default(TOutput);
                }

                return (action == null) ? default(TOutput) : action(input);
            }
            catch (Exception exception)
            {
                //var errorMessage = "Mapping '{0}' --> '{1}' failed due to {2} - \"{3}\" !".FormatWith(
                //    typeof(TInput).FullName,
                //    typeof(TOutput).FullName,
                //    exception.GetType().FullName,
                //    exception.Message);

                throw;
            }
        }
    }

    public interface IMapper
    {
        TTo Map<TFrom, TTo>(TFrom input)
            where TFrom : class
            where TTo : class;
    }

    public class PersonMapper<TFrom, TTo> : IMapper
        where TFrom : class
        where TTo : class
    {
        public TTo Map<TFrom, TTo>(TFrom input)
            where TFrom : class
            where TTo : PersonDto
        {
            return new PersonDto();
        }
    }

    public class PersonService
    {
        private IMapper _mapper;

        public PersonService(IMapper mapper)
        {
            _mapper = mapper;
        }

        internal PersonDto GetPerson(Person person)
        {
            var dto = _mapper.Map<Person, PersonDto>(person);

            return dto;
        }

        internal IEnumerable<PersonDto> GetPersons()
        {
            throw new NotImplementedException();
        }
    }

    public class MapperTest
    {
        [Fact]
        public void ShouldMap()
        {
            var mapper = A.Fake<IMapper>();
            A.CallTo(() => mapper.Map<Person, PersonDto>(A<Person>.Ignored)).Returns(new PersonDto());

            var sut = new PersonService(new PersonMapper());

            var result = sut.GetPerson(new Person());

            Assert.NotNull(result);
        }
    }
}
