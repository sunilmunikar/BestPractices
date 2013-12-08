using Core;
using Core.Entities;
using Core.Services;
using GenericRepository.EntityFramework;
using Microsoft.Practices.Unity;

namespace MvcDemos.DI.Unity.ContainerExtensions
{
    public class MvcDemosContainerExtension
        : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IEntitiesContext, MvcDemosEntities>();
            Container.RegisterType<IEntityRepository<Genre>, EntityRepository<Genre>>();
            Container.RegisterType<IGenreService, GenreService>();
        }
    }
}