using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;

namespace GggWebApplication.Filters.Attributes
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1#dependency-injection
    /// TypeFilterAttribute Class
    /// A filter that creates another filter of type ImplementationType, retrieving
    /// missing constructor arguments from dependency injection if available there
    /// </summary>
    public class SampleActionFilterAttribute : TypeFilterAttribute
    {
        public SampleActionFilterAttribute() : base(typeof(SampleActionFilterImpl))
        {
            Console.WriteLine("GggMessage: " + GetType().FullName + ": SampleActionFilterAttribute Constructor called.");
        }
        private class SampleActionFilterImpl : IActionFilter
        {
            private readonly ILogger _logger;
            public SampleActionFilterImpl(ILoggerFactory loggerFactory)
            {
                _logger = loggerFactory.CreateLogger<SampleActionFilterAttribute>();
            }

            public void OnActionExecuting(ActionExecutingContext context)
            {
                Console.WriteLine("GggMessage: " + GetType().FullName + ": OnActionExecuting");
                _logger.LogInformation("Business action starting...");
                // perform some business logic work

            }

            public void OnActionExecuted(ActionExecutedContext context)
            {
                Console.WriteLine("GggMessage: " + GetType().FullName + ": OnActionExecuted");
                // perform some business logic work
                _logger.LogInformation("Business action completed.");
            }
        }
    }
}
