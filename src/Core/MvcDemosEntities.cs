using System.Data.Entity;
using GenericRepository.EntityFramework;

namespace Core
{
    public class MvcDemosEntities : EntitiesContext
    {
        public IDbSet<Entities.Genre> Genres { get; set; }
    }
}