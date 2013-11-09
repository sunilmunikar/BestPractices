﻿using System.Collections.Generic;
using Core.Entities;

namespace MvcDemos.Controllers
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