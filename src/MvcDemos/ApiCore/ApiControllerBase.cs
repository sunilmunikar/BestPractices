using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcDemos.ApiCore
{
    public class ApiControllerBase : ApiController
    {
        protected HttpResponseMessage GetHttpResponse(HttpRequestMessage request, Func<HttpResponseMessage> codeToExecute)
        {
            HttpResponseMessage response = null;

            try
            {
                response = codeToExecute.Invoke();
            }
            catch (FluentValidation.ValidationException ex)
            {
                var result = ex.Errors.Select(item => new System.ComponentModel.DataAnnotations.ValidationResult(item.ErrorMessage, new List<string> { item.PropertyName }));
                response = request.CreateResponse(HttpStatusCode.BadRequest, result);
            }
            //catch (SecurityException ex)
            //{
            //    response = request.CreateResponse(HttpStatusCode.Unauthorized, ex.Message);
            //}
            //catch (FaultException<AuthorizationValidationException> ex)
            //{
            //    response = request.CreateResponse(HttpStatusCode.Unauthorized, ex.Message);
            //}
            //catch (FaultException ex)
            //{
            //    response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            //}
            catch (Exception ex)
            {
                response = request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return response;
        }
    }
}