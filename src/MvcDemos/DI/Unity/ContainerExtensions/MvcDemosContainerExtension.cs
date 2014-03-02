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
            Container.RegisterType<IEntityRepository<Album>, EntityRepository<Album>>();

            Container.RegisterType<IValidatorFactory, FluentValidatorFactory>();
            Container.RegisterType<IValidator<Genre>, HasPermissionToGet>();

            Container.RegisterInstance(Mapper.Engine);

            SetupValidation();

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

            Container.RegisterType<IValidationProvider, ValidationProvider>(new InjectionConstructor(validatorFactory));
            Container.RegisterType<Validator<Core.Dtos.AlbumDto>, AlbumValidator>();
        }
    }

    public abstract class ValidatorFactoryBase
    {
        public Core.Services.Validation.IValidator GetValidator(Type type)
        {
            var genericType = typeof(IValidator<>).MakeGenericType(type);
            return CreateInstance(genericType);
        }

        public abstract Core.Services.Validation.IValidator CreateInstance(Type genericType);
    }
}