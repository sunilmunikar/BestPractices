using System.Data.Entity;
using GenericRepository.EntityFramework;

namespace Core
{
    public class MvcDemosEntities : EntitiesContext
    {
        // NOTE: You have the same constructors as the DbContext here. E.g:
        // public MvcDemosEntities() : base("nameOrConnectionString") { }

        public IDbSet<Entities.Genre> Genres { get; set; }
    }
}