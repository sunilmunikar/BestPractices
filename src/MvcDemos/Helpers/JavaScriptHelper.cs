using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace MvcDemos.Helpers
{
    public static class JavaScriptHelper
    {
        public static IHtmlString SerializeObject(object value)
        {
            using (var stringWriter = new StringWriter())
            using (var jsonWriter = new JsonTextWriter(stringWriter))
            {
                var serializer = new JsonSerializer
                {
                    // Let's use camelCasing as is common practice in JavaScript
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                // We don't want quotes around object names
                jsonWriter.QuoteName = false;
                serializer.Serialize(jsonWriter, value);

                return new HtmlString(stringWriter.ToString());
            }
        }

        public static IHtmlString Json(this HtmlHelper helper, object obj)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new JsonConverter[]
				{
					new StringEnumConverter(),
				},
                StringEscapeHandling = StringEscapeHandling.EscapeHtml
            };

            return MvcHtmlString.Create(JsonConvert.SerializeObject(obj, settings));
        }
    }
}