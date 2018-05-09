using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace GggWebApplication.Filters
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1#feedback
    /// A filter that surrounds execution of the action
    /// Synchronous filters that can run code both before and after their
    /// pipeline stage define OnStageExecuting and OnStageExecuted methods.
    /// For example, OnActionExecuting is called before the action method is called,
    /// and OnActionExecuted is called after the action method returns.
    /// </summary>
    public class SampleActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // do something before the action executes
            Console.WriteLine("GggMessage: " + GetType().FullName + " " + "OnActionExecuting");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // do something after the action executes
            Console.WriteLine("GggMessage: " + GetType().FullName + " " + "OnActionExecuted");
        }
    }
}
