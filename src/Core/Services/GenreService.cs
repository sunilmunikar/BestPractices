using Core.Entities;
using GenericRepository.EntityFramework;
using System.Collections.Generic;

namespace Core.Services
{
    public class GenreService : IGenreService
    {
        private readonly IEntityRepository<Genre> _genreRepository;

        public GenreService(IEntityRepository<Genre> genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _genreRepository.GetAll();
        }

        public Genre GetGenre(int id)
        {
            throw new System.NotImplementedException();
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