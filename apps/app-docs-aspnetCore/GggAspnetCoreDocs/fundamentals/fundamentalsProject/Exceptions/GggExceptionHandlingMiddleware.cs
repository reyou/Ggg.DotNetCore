using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Microsoft.Net.Http.Headers;

namespace fundamentalsProject.Exceptions
{
    /// <summary>
    /// https://stackoverflow.com/questions/38630076/asp-net-core-web-api-exception-handling/
    /// https://stackoverflow.com/a/51847739/929902
    /// </summary>
    public class GggExceptionHandlingMiddleware
    {
        // A function that can process an HTTP request.
        private readonly RequestDelegate _next;
        private readonly IActionResultExecutor<ObjectResult> _executor;
        private ILogger<GggExceptionHandlingMiddleware> _logger;
        private static readonly ActionDescriptor EmptyActionDescriptor = new ActionDescriptor();

        public GggExceptionHandlingMiddleware(RequestDelegate next, IActionResultExecutor<ObjectResult> executor, ILoggerFactory loggerFactory)
        {
            _next = next;
            _executor = executor;
            _logger = loggerFactory.CreateLogger<GggExceptionHandlingMiddleware>();
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"An unhandled exception has occurred while executing the request. Url: {context.Request.GetDisplayUrl()}. Request Data: " + GetRequestData(context));

                if (context.Response.HasStarted)
                {
                    throw;
                }

                RouteData routeData = context.GetRouteData() ?? new RouteData();

                ClearCacheHeaders(context.Response);

                ActionContext actionContext = new ActionContext(context, routeData, EmptyActionDescriptor);

                ObjectResult result = new ObjectResult(new ErrorResponse("Error processing request. Server error."))
                {
                    StatusCode = (int)HttpStatusCode.InternalServerError,
                };

                await _executor.ExecuteAsync(actionContext, result);
            }
        }

        private static void ClearCacheHeaders(HttpResponse response)
        {
            response.Headers[HeaderNames.CacheControl] = "no-cache";
            response.Headers[HeaderNames.Pragma] = "no-cache";
            response.Headers[HeaderNames.Expires] = "-1";
            response.Headers.Remove(HeaderNames.ETag);
        }


        private static string GetRequestData(HttpContext context)
        {
            StringBuilder sb = new StringBuilder();

            if (context.Request.HasFormContentType && context.Request.Form.Any())
            {
                sb.Append("Form variables:");
                foreach (KeyValuePair<string, StringValues> x in context.Request.Form)
                {
                    sb.AppendFormat("Key={0}, Value={1}<br/>", x.Key, x.Value);
                }
            }

            sb.AppendLine("Method: " + context.Request.Method);

            return sb.ToString();
        }
    }

    [DataContract(Name = "ErrorResponse")]
    public class ErrorResponse
    {
        [DataMember(Name = "Message")]
        public string Message { get; set; }

        public ErrorResponse(string message)
        {
            Message = message;
        }
    }
}
