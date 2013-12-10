using System.Data.Entity;
using Core.Entities;
using GenericRepository.EntityFramework;

namespace Core
{
    public class MusicStoreEntities : EntitiesContext
    {
        // NOTE: You have the same constructors as the DbContext here. E.g:
        // public MvcDemosEntities() : base("nameOrConnectionString") { }

        public MusicStoreEntities()
            : base("DefaultConnection")
        {
    
        }

        public IDbSet<Album> Albums { get; set; }
        public IDbSet<Genre> Genres { get; set; }
        public IDbSet<Artist> Artists { get; set; }
        public IDbSet<Cart> Carts { get; set; }
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<OrderDetail> OrderDetails { get; set; }
    }
}