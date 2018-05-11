using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System.Linq;

namespace GggWebApplication.Filters.Attributes
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1#feedback
    /// A filter that surrounds execution of the action
    /// Synchronous filters that can run code both before and after their
    /// pipeline stage define OnStageExecuting and OnStageExecuted methods.
    /// For example, OnActionExecuting is called before the action method is called,
    /// and OnActionExecuted is called after the action method returns.
    /// </summary>
    public class HeaderSecurityFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            StringValues securityHeader = context.HttpContext.Request.Headers["CustomSecurityHeader"];
            string securitValue = securityHeader.FirstOrDefault();
            if (string.IsNullOrEmpty(securitValue))
            {
                //  throw new ArgumentNullException("context", "CustomSecurityHeader header is missing.");
                context.Result = new BadRequestObjectResult(new
                {
                    Error = "Not Authorized. CustomSecurityHeader expected."
                });
            }
        }
    }
}
