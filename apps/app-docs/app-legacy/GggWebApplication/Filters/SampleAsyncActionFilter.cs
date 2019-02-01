using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Threading.Tasks;

namespace GggWebApplication.Filters
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1#feedback
    /// Asynchronous filters define a single OnStageExecutionAsync method. This
    /// method takes a FilterTypeExecutionDelegate delegate which executes
    /// the filter's pipeline stage. For example, ActionExecutionDelegate
    /// calls the action method, and you can execute code before and after
    /// you call it
    /// </summary>
    public class SampleAsyncActionFilter : IAsyncActionFilter
    {
        /* ActionExecutingContext Class: A context for action filters, specifically
         OnActionExecuted(ActionExecutedContext) and 
         OnActionExecutionAsync(ActionExecutingContext, ActionExecutionDelegate) calls.*/
        /* ActionExecutionDelegate Delegate: A delegate that asynchronously returns an
         ActionExecutedContext indicating the action or the next action filter has executed.*/
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // do something before the action executes
            ActionExecutedContext resultContext = await next();
            Console.WriteLine(GetType().FullName + ": " + "OnActionExecutionAsync called.");
            // do something after the action executes; resultContext.Result will be set
        }
    }
}
