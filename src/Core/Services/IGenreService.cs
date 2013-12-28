using System.Collections.Generic;
using Core.Dtos;
using Core.Entities;

namespace Core.Services
{
    public interface IGenreService
    {
        IEnumerable<Genre> GetGenres();
        PaginatedDto<GenreDto> GetGenres(int pageIndex, int pageSize);
        Genre GetGenre(int id);
        void Update(Genre genre);
        void Add(Genre genre);
        void Delete(int id);
    }
}