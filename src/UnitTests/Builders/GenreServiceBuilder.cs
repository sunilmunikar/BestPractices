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

namespace UnitTests.Core.Services
{
    public class GenreServiceBuilder
    {
        private IEntityRepository<Genre> _genreRepository;
        private IValidatorFactory _validator;
        private IMappingEngine _mapper;

        public GenreService Build()
        {
            return new GenreService(_genreRepository, _validator, _mapper);
        }

        public GenreServiceBuilder WithFakeGenreRepository(IEntityRepository<Genre> genreRepository)
        {
            _genreRepository = genreRepository;

            return this;
        }

        public GenreServiceBuilder WithDefaultFakeValidator()
        {
            IValidatorFactory _validatorFactory = A.Fake<IValidatorFactory>();
            _validator = _validatorFactory;
            return this;
        }

        public GenreServiceBuilder WithDefaultFakeMapper()
        {
            var fakeMapping = A.Fake<IMappingEngine>();
            _mapper = fakeMapping;

            return this;
        }

        public GenreServiceBuilder WithFakeMapper(IMappingEngine mapper)
        {
            _mapper = mapper;

            return this;
        }
    }
}
