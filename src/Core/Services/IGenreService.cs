using Core.Entities;
using System.Collections.Generic;

namespace Core.Services
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetGenres();
        Genre GetGenre(int id);
        void Update(Genre genre);
        void Add(Genre genre);
        void Delete(int id);
    }
}