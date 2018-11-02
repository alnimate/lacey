using System.Net;
using Lacey.Medusa.Common.Web.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Lacey.Medusa.Common.Web.Validation
{
    public sealed class ModelErrorsFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (!(context.Exception is InvalidModelException))
            {
                throw context.Exception;
            }

            var modelException = (InvalidModelException)context.Exception;

            context.ExceptionHandled = true;
            var response = context.HttpContext.Response;
            response.Clear();
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            response.Body.WriteAsJson(modelException.Errors);
        }
    }
}