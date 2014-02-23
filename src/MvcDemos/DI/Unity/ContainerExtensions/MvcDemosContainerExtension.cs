using AutoMapper;
using AutoMapper.Mappers;
using Core;
using Core.Entities;
using Core.Handlers;
using Core.Services;
using Core.Services.Validation;
using FluentValidation;
using GenericRepository.EntityFramework;
using Microsoft.Practices.Unity;
using System;

namespace MvcDemos.DI.Unity.ContainerExtensions
{
    public class MvcDemosContainerExtension
        : UnityContainerExtension
    {
        protected override void Initialize()
        {
            Container.RegisterType<IEntitiesContext, MvcDemosEntities>();
            Container.RegisterType<IEntityRepository<Genre>, EntityRepository<Genre>>();

            Container.RegisterType<IValidatorFactory, FluentValidatorFactory>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IValidator<Genre>, HasPermissionToGet>();

            Container.RegisterInstance(Mapper.Engine);

            Container.RegisterType<IGenreService, GenreService>();

            Container.RegisterType<IAlbumService, AlbumService>();


        }

        private void SetupValidation()
        {
            Func<Type, Core.Services.Validation.IValidator> validatorFactory = type =>
            {
                var valType = typeof(Validator<>).MakeGenericType(type);
                return (Core.Services.Validation.IValidator)Container.Resolve(valType);
            };

            Container.RegisterType<IValidationProvider, ValidationProvider>("validatorFactory");
            Container.RegisterType<Validator<Core.Dtos.AlbumDto>, AlbumValidator>();
        }

        //public class MyValidatorFactory : ValidatorFactoryBase
        //{
        //    private readonly IUnityContainer _container;

        //    public MyValidatorFactory(IUnityContainer container)
        //    {
        //        _container = container;
        //    }

        //    public override Core.Services.IValidator CreateInstance(Type validatorType)
        //    {
        //        return _container.Resolve(validatorType) as IValidator;
        //    }
        //}
    }
}