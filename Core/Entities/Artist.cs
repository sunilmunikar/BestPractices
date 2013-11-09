using GenericRepository;

namespace Core.Entities
{
    public class Artist : IEntity
    {
        public int Id { get; set; }
        public int ArtistId { get; set; }
        public string Name { get; set; }
    }
}