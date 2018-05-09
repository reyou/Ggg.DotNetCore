using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace GggWebApplication.Filters
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1#feedback
    /// The framework includes built-in attribute-based filters that you can
    /// subclass and customize. For example, the following Result filter adds
    /// a header to the response.
    /// </summary>
    /*ResultFilterAttribute Class: An abstract filter that asynchronously surrounds execution
     of the action result. Subclasses must override OnResultExecuting(ResultExecutingContext), 
     OnResultExecuted(ResultExecutedContext) or 
     OnResultExecutionAsync(ResultExecutingContext, ResultExecutionDelegate) but not 
     OnResultExecutionAsync(ResultExecutingContext, ResultExecutionDelegate) and either of the other two.*/
    public class AddHeaderAttribute : ResultFilterAttribute
    {
        private readonly string _name;
        private readonly string _value;

        public AddHeaderAttribute(string name, string value)
        {
            _name = name;
            _value = value;
        }
        // ResultExecutingContext Class: A context for result filters, specifically
        // OnResultExecuting(ResultExecutingContext) and
        // OnResultExecutionAsync(ResultExecutingContext, ResultExecutionDelegate) calls.
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            Console.WriteLine("GggMessage: " + GetType().FullName + ": OnResultExecuting");
            context.HttpContext.Response.Headers.Add(_name, new[] { _value });
            base.OnResultExecuting(context);
        }
    }

}
