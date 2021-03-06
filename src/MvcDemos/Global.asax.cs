﻿using System;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using AutoMapper;
using Core;
using Core.Dtos;
using FluentValidation.Mvc;
using FluentValidation.Validators;
using GenericRepository;
using MvcDemos.Validators;
using Core.Entities;
using MvcDemos.ViewModels;
using MvcDemos.MvcCore;
using System.Globalization;
using System.Threading;
using MvcDemos.App_Start;

namespace MvcDemos
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new SampleData());

            AreaRegistration.RegisterAllAreas();

            FluentSecurityConfig.SetupFluentSecurity();

            //WebApiConfig.Register(GlobalConfiguration.Configuration);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            RegisterMappings();

            //FluentValidationModelValidatorProvider.Configure();
            FluentValidationModelValidatorProvider.Configure(provider =>
            {
                provider.Add(typeof(NotEqualValidator), (metadata, context, description, validator) => new NotEqualPropertyValidator(metadata, context, description, validator));
                provider.Add(typeof(LessThanOrEqualValidator), (metadata, context, rule, validator) => new LessThanOrEqualToFluentValidationPropertyValidator(metadata, context, rule, validator));
            });

            // NOTE: Remove the following lines if you need .aspx support
            ViewEngines.Engines.Clear();
            //ViewEngines.Engines.Add(new RazorViewEngine());
            ViewEngines.Engines.Add(new ModularConventionViewEngine());

            MvcHandler.DisableMvcResponseHeader = true;
        }

        public static void RegisterMappings()
        {
            MapForPaginatedDto<Genre, GenreDto>();
            //Mapper.CreateMap<GenreEditModel, GenreDto>();
        }

        private static void MapForPaginatedDto<TEntity, TDto>() where TDto : IDto
        {
            Mapper.CreateMap<TEntity, TDto>();
            Mapper.CreateMap<PaginatedList<TEntity>, PaginatedDto<TDto>>()
                            .ForMember(dest => dest.Items,
                                       opt => opt.MapFrom(
                                           src => src.Select(
                                               entity => Mapper.Map<TEntity, TDto>(entity))));

        }

        protected void Application_Error()
        {
            var error = Server.GetLastError();
        }
    }
}