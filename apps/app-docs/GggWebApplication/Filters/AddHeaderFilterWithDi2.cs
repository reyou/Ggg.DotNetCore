using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace GggWebApplication.Filters
{
    // IResultFilter Interface
    // A filter that surrounds execution of action results
    // successfully returned from an action
    public class AddHeaderFilterWithDi2 : IResultFilter
    {
        // ILogger Interface
        // Represents a type used to perform logging
        private ILogger _logger;
        // ILoggerFactory Interface
        // Represents a type used to configure the logging system and
        // create instances of ILogger from the registered ILoggerProviders
        public AddHeaderFilterWithDi2(ILoggerFactory loggerFactory)
        {
            Console.WriteLine("GggMessage: " + GetType().FullName + ": AddHeaderFilterWithDi2");
            if (loggerFactory == null)
            {
                loggerFactory = new LoggerFactory();
            }
            _logger = loggerFactory.CreateLogger<AddHeaderFilterWithDi2>();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("GggMessage: " + GetType().FullName + ": OnResultExecuting");
            string headerName = "OnResultExecuting";
            context.HttpContext.Response.Headers.Add(headerName, new[] { "ResultExecutingSuccessfully" });
            _logger.LogInformation($"Header added: {headerName}");
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            // Can't add to headers here because response has already begun.
            Console.WriteLine("GggMessage: " + GetType().FullName + ": OnResultExecuted");
            Console.WriteLine("GggMessage: " + GetType().FullName + ": Can't add to headers here because response has already begun.");
        }
    }

}
