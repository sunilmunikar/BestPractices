using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Globalization;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using WebApiDemos.ExceptionHandling;

namespace WebApiDemos
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration httpConfiguration)
        {
            // Web API configuration and services

            // Web API routes
            httpConfiguration.MapHttpAttributeRoutes();

            httpConfiguration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            httpConfiguration.Services.Add(typeof(IExceptionLogger), new NLogExceptionLogger());
            httpConfiguration.Services.Add(typeof(IExceptionLogger), new ElmahExceptionLogger());
            httpConfiguration.Services.Replace(typeof(IExceptionHandler), new ApiExceptionHandler());

            //httpConfiguration.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
            //    new CamelCasePropertyNamesContractResolver();

            // WebApi formatters
            var formatters = httpConfiguration.Formatters;
            formatters.Remove(formatters.XmlFormatter);


            // Set json formatters
            var jsonFormatter = formatters.JsonFormatter;
            var jsonSettings = new Newtonsoft.Json.JsonSerializerSettings()
            {
                Formatting = Formatting.Indented, // Nice for debugging I think, looks pretty
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,  // Fix JSON.NET self referencing hell
                ContractResolver = new CamelCasePropertyNamesContractResolver(),  // automatic camelCasing
                Culture = new CultureInfo("fr-BE")
            };

            // add a custom date formatter to override Datetime format settings
            //jsonSettings.Converters.Add(new MyDateFormatConverter());

            // Finally set new settings to global config
            jsonFormatter.SerializerSettings = jsonSettings;

            //httpConfiguration.Formatters.JsonFormatter.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
            //httpConfiguration.Formatters.JsonFormatter.SerializerSettings.Culture = new CultureInfo("fr-FR");
            //httpConfiguration.Formatters.JsonFormatter.SerializerSettings.Converters.Add(new MyDateFormatConverter());

        }
    }

    public class MyDateFormatConverter : DateTimeConverterBase
    {
        public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
        {
            return DateTime.Parse(reader.Value.ToString());
        }

        public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
        {
            //writer.WriteValue(((DateTime)value).ToString("d", CultureInfo.CreateSpecificCulture("fr-BE")));
            writer.WriteValue(((DateTime)value).ToString("dd/MM/yyyy hh:mm"));

            // General Datetime pattern (short-time) 6/15/2009 1:45:30 PM -> 6/15/2009 1:45:30 PM (en-US)
            //writer.WriteValue(((DateTime)value).ToString("g", CultureInfo.CreateSpecificCulture("en-US")));

            // Full date/time pattern (short time) 6/15/2009 1:45:30 PM -> Monday, June 15, 2009 1:45 PM (en-US)
            //writer.WriteValue(((DateTime)value).ToString("f", CultureInfo.CreateSpecificCulture("en-US")));

        }
    }

    public class CustomDateTimeConverter : IsoDateTimeConverter
    {
        public CustomDateTimeConverter()
        {
            base.DateTimeFormat = "dd/MM/yyyy";
        }
    }
}
