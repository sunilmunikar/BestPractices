using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcDemos.MvcCore
{
    public class CustomModelMetadataProvider : DataAnnotationsModelMetadataProvider
    {
        public override ModelMetadata GetMetadataForProperty(Func<object> modelAccessor, Type containerType, string propertyName)
        {
            var result = base.GetMetadataForProperty(modelAccessor, containerType, propertyName);
            if (result.TemplateHint == null &&
                typeof(Enum).IsAssignableFrom(result.ModelType))
            {
                result.TemplateHint = "Enum";
            }
            return result;
        }
    }
}