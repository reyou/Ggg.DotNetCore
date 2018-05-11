using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace GggWebApplication.Filters.Attributes
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1#action-filters
    /// </summary>
    /*To short-circuit, assign ActionExecutingContext.Result to some result
    instance and don't call the ActionExecutionDelegate.
    The framework provides an abstract ActionFilterAttribute that you can subclass.
    You can use an action filter to validate model state and return any errors if 
    the state is invalid:*/
    // ActionFilterAttribute Class: An abstract filter that asynchronously surrounds
    // execution of the action and the action result
    // ActionExecutingContext Class: A context for action filters, specifically
    // OnActionExecuted(ActionExecutedContext) and
    // OnActionExecutionAsync(ActionExecutingContext, ActionExecutionDelegate) calls
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            Console.WriteLine("GggMessage: " + GetType().FullName + ": OnActionExecuting");
            Console.WriteLine("GggMessage: " + GetType().FullName + ": context.ModelState.IsValid: " + context.ModelState.IsValid);

            if (!context.ModelState.IsValid)
            {
                // ModelStateDictionary Class
                // Represents the state of an attempt to bind values from an
                // HTTP Request to an action method, which includes validation information
                // BadRequestObjectResult Class
                // An ObjectResult that when executed will produce a Bad Request (400) response
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
