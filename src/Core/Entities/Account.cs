using GenericRepository;

namespace Core.Entities
{
    public class Account : IEntity
    {
        //[Required]
        //[StringLength(20, MinimumLength = 4)]
        public string Username { get; set; }
        public int Id { get; set; }
    }
}