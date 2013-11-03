using System.Collections.Generic;
using GenericRepository;

namespace MvcDemos.Models
{
    public class Genre : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Album> Albums { get; set; }
    }
}
