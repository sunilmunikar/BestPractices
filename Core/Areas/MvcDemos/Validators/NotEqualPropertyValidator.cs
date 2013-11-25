using System;
using System.Collections.Generic;
using System.Web.Mvc;
using FluentValidation.Internal;
using FluentValidation.Mvc;
using FluentValidation.Validators;

namespace MvcDemos.Validators
{
    public class NotEqualPropertyValidator : FluentValidationPropertyValidator
    {
        public NotEqualPropertyValidator(
            ModelMetadata metadata, ControllerContext controllerContext, PropertyRule rule, IPropertyValidator validator)
            : base(metadata, controllerContext, rule, validator)
        {
        }

        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            if (!ShouldGenerateClientSideRules()) yield break;

            var formatter = new MessageFormatter().AppendPropertyName(Rule.PropertyName);
            string message = formatter.BuildMessage(Validator.ErrorMessageSource.GetString());
            var rule = new ModelClientValidationRule
            {
                ValidationType = "notequal",
                ErrorMessage = message
            };
            rule.ValidationParameters["field"] = String.Format("#{0}", ((NotEqualValidator)Validator).MemberToCompare.Name);
            yield return rule;
        }
    }
}