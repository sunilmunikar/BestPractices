using System.Collections.Generic;
using AutoMapper;
using Core.Dtos;
using Core.Entities;
using FluentValidation;
using FluentValidation.Results;
using GenericRepository;
using GenericRepository.EntityFramework;

namespace Core.Services
{
    public class GenreService : IGenreService
    {
        private readonly IEntityRepository<Genre> _genreRepository;
        private readonly FluentValidation.IValidator<Genre> _hasPermission;
        private readonly IMappingEngine _mapper;

        public GenreService(
            IEntityRepository<Genre> genreRepository
            ,
            FluentValidation.IValidatorFactory validatorFactory
            ,
            IMappingEngine mapper
            )
        {
            _genreRepository = genreRepository;
            _hasPermission = validatorFactory.GetValidator<Genre>();
            _mapper = mapper;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _genreRepository.GetAll();
        }

        public PaginatedDto<GenreDto> GetGenres(int pageIndex, int pageSize)
        {
            //return _genreRepository.GetAll();
            PaginatedList<Genre> entities = _genreRepository.Paginate(pageIndex, pageSize);
            PaginatedDto<GenreDto> dtos = _mapper.Map<PaginatedList<Genre>, PaginatedDto<GenreDto>>(entities);
            return dtos;
        }

        public Genre GetGenre(int id)
        {
            Genre result = _genreRepository.GetSingle(id);

            FluentValidation.Results.ValidationResult validationResult = _hasPermission.Validate(result);
            //_hasPermission.ValidateAndThrow(result);

            return result;
        }

        public void Update(Genre genre)
        {
            _genreRepository.Add(genre);
            _genreRepository.Save();
        }

        public void Add(Genre genre)
        {
            _genreRepository.Add(genre);
            _genreRepository.Save();
        }

        public void Delete(int id)
        {
            Genre genre = _genreRepository.GetSingle(id);
            //if(genre == null)
            //    throw new HttpResponseException(HttpStatusCode.NotFound);
            _genreRepository.Delete(genre);
            _genreRepository.Save();
        }
    }
}