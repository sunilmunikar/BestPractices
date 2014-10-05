using System;
using System.Collections.Generic;
using System.Net;
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
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int? id)
        {
            if (id == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return string.Empty;
        }

        // POST api/values
        public void Post(Team value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}