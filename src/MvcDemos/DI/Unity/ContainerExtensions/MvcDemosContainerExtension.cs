using AutoMapper;
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
            Container.RegisterType<FluentValidation.IValidator<Genre>, HasPermissionToGet>();

            Container.RegisterInstance(Mapper.Engine);

            Container.RegisterInstance(System.Web.Http.GlobalConfiguration.Configuration);

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
}