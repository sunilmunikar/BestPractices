using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using FakeItEasy;
using Xunit;

namespace UnitTests.Framework.Mvc.HtmlHelper
{
    public static class HtmlHelperExtension
    {
        //public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, 
        //    Expression<Func<TModel, TProperty>> expression, 
        //    IEnumerable<SelectListItem> selectList);

        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TEnum>> expression,
            object htmlAttributes = null)
        {
            //IEnumerable<SelectListItem> items = new[]
            //                                        {
            //                                            new SelectListItem
            //                                                {
            //                                                    Text = "Foo",
            //                                                    Value = "Value"
            //                                                }
            //                                        };
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var realModelType = metadata.ModelType;
            Type underlyingType = Nullable.GetUnderlyingType(metadata.ModelType);

            if (underlyingType != null)
                realModelType = underlyingType;


            IEnumerable<TEnum> enumValues = Enum.GetValues(realModelType).Cast<TEnum>();

            IEnumerable<SelectListItem> items = enumValues.Select(x => new SelectListItem()
                                                                     {
                                                                         Text = "Foo",
                                                                         Value = x.ToString(),
                                                                         Selected = x.Equals(metadata.Model)
                                                                     });

            return htmlHelper.DropDownListFor(expression, items, htmlAttributes);
        }
    }

    public class HtmlEnumHelperTests
    {
        [Fact]
        public void CanGetDropDownForDecoratedEnum()
        {
            var htmlHelper = CreateHtmlHelper<SimpleModel>();
            var result = htmlHelper.EnumDropDownListFor(x => x.DecoratedType);
            Console.WriteLine(result);

            Assert.Contains("Foo", result.ToString(), StringComparison.CurrentCultureIgnoreCase);
        }

        private static HtmlHelper<TModel> CreateHtmlHelper<TModel>()
        {
            //var httpContext = A.Fake<HttpContextBase>();
            //A.CallTo(() => httpContext.Items).Returns(new Dictionary<object, object>());

            //var viewContext = new ViewContext { HttpContext = httpContext, ViewData = new ViewDataDictionary() };

            //var viewDataContainer = A.Fake<IViewDataContainer>();
            //A.CallTo(() => viewDataContainer.ViewData).Returns(new ViewDataDictionary());

            //var htmlHelper = new HtmlHelper<TModel>(viewContext, viewDataContainer);
            //return htmlHelper;

            var viewContext = new ViewContext
            {
                HttpContext = new FakeHttpContext(),
                ViewData = new ViewDataDictionary()
            };

            return new HtmlHelper<TModel>(viewContext, new FakeViewDataContainer());
        }
    }

    public class FakeViewDataContainer : IViewDataContainer
    {
        public FakeViewDataContainer()
        {
            ViewData = new ViewDataDictionary();
        }

        public ViewDataDictionary ViewData { get; set; }
    }

    public class FakeHttpContext : HttpContextBase
    {
        private readonly Dictionary<object, object> items = new Dictionary<object, object>();

        public override IDictionary Items
        {
            get
            {
                return items;
            }
        }
    }

    public class SimpleModel
    {
        [Description("TModel")]
        public string Name { get; set; }

        public SimpleEnum DecoratedType { get; set; }
    }

    public enum SimpleEnum
    {
        [Description("foo")]
        Foo,
        [Description("bar")]
        Bar,
    }
}