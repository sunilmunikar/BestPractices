using System;
using FluentValidation;
using Microsoft.Practices.Unity;

namespace MvcDemos.DI.Unity.ContainerExtensions
{
    public class UnityValidatorFactory : ValidatorFactoryBase
    {
        private readonly IUnityContainer _container;

        public UnityValidatorFactory(IUnityContainer container)
        {
            _container = container;
        }

        public override FluentValidation.IValidator CreateInstance(Type validatorType)
        {
            return _container.Resolve(validatorType) as FluentValidation.IValidator;
        }
    }
}