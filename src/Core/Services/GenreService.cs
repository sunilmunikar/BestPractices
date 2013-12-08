using Core.Entities;
using Core.Handlers;
using FluentValidation;
using GenericRepository.EntityFramework;
using System.Collections.Generic;

namespace Core.Services
{
    public class GenreService : IGenreService
    {
        private readonly IEntityRepository<Genre> _genreRepository;
        private readonly IValidator<Genre> _hasPermission;

        public GenreService(IEntityRepository<Genre> genreRepository, IValidator<Genre> hasPermission )
        {
            _genreRepository = genreRepository;
            _hasPermission = hasPermission;
        }

        public IEnumerable<Genre> GetGenres()
        {
            
            return _genreRepository.GetAll();
        }

        public Genre GetGenre(int id)
        {
            Genre result = _genreRepository.GetSingle(id);
                       
            //var validationResult = _hasPermission.Validate(result);
            _hasPermission.ValidateAndThrow(result);

            return result;
        }

        public void Update(Genre genre)
        {
            _genreRepository.Add(genre);
            _genreRepository.Save();
        }

        public void Add(Genre genre)
        {
            throw new System.NotImplementedException();
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