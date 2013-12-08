using AutoMapper;
using AutoMapper.Mappers;
using Core;
using Core.Entities;
using Core.Handlers;
using Core.Services;
using FluentValidation;
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
            Container.RegisterType<IValidator<Genre>, HasPermissionToGet>();

            Container.RegisterInstance(Mapper.Engine);

            Container.RegisterType<IGenreService, GenreService>();
        }
    }
}