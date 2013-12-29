using System.Web.Http;
using Core.Dtos;
using Core.Services;
using Core.Entities;

namespace MvcDemos.ApiControllers
{
    public class GenreController : ApiController
    {
        private readonly IGenreService _genreService;

        //public GenreController()
        //{
            
        //}

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

         //GET api/<controller>
        public PaginatedDto<GenreDto> GetAll()
        {
            PaginatedDto<GenreDto> result = _genreService.GetGenres(1, 1);
            return result;
        }

        // GET api/<controller>/5
        public Genre Get(int id)
        {
            return _genreService.GetGenre(id);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}