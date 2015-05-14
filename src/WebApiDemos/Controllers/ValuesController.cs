using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Web.Http;

namespace WebApiDemos.Controllers
{
    public class ValuesController : ApiController
    {
        public void LogExceptionTest()
        {
            throw new NotImplementedException("testing");
        }

        // GET api/values
        public IHttpActionResult Get()
        {
            var result = new User
            {
                Age = 34,
                Birthdate = DateTime.Now,
                ConvertedUsingAttribute = DateTime.Now,
                Firstname = "Ugo",
                Lastname = "Lattanzi",
                IgnoreProperty = "This text should not appear in the reponse",
                Salary = 1000,
                Username = "imperugo",
                Website = new Uri("http://www.tostring.it")
            };

            return Ok(result);
        }

        // GET api/values/5
        public HttpResponseMessage Get(int? id)
        {
            if (id == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            var result = new User
                {
                    Age = 34,
                    Birthdate = DateTime.Now,
                    ConvertedUsingAttribute = DateTime.Now,
                    Firstname = "Ugo",
                    Lastname = "Lattanzi",
                    IgnoreProperty = "This text should not appear in the reponse",
                    Salary = 1000,
                    Username = "imperugo",
                    Website = new Uri("http://www.tostring.it")
                };

            var formatter = new JsonMediaTypeFormatter();
            var json = formatter.SerializerSettings;

            json.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.IsoDateFormat;
            json.DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Utc;
            json.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            json.Formatting = Newtonsoft.Json.Formatting.Indented;
            json.ContractResolver = new CamelCasePropertyNamesContractResolver();
            json.Culture = new CultureInfo("en-US");

            return Request.CreateResponse(HttpStatusCode.OK, result, formatter);


        }


        // POST api/values
        public void Post(Team value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]Team value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }

    //public class CustomDateTimeConverter : IsoDateTimeConverter
    //{
    //    public CustomDateTimeConverter()
    //    {
    //        base.DateTimeFormat = "dd/MM/yyyy";
    //    }
    //}


}
