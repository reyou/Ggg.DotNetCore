using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace GggWebApplication.Filters.Attributes
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1#feedback
    /// https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.mvc.filters.iresourcefilter?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev15.query%3FappId%3DDev15IDEF1%26l%3DEN-US%26k%3Dk(Microsoft.AspNetCore.Mvc.Filters.IResourceFilter);k(DevLang-csharp)%26rd%3Dtrue&view=aspnetcore-2.1
    /// http://localhost:11781/sample/SomeResource
    /// IResourceFilter Interface: A filter that surrounds execution of model binding,
    /// the action (and filters) and the action result (and filters).
    /// </summary>
    public class ShortCircuitingResourceFilterAttribute : Attribute, IResourceFilter
    {
        public void OnResourceExecuting(ResourceExecutingContext context)
        {
            Console.WriteLine("GggMessage: " + GetType().FullName + ": OnResourceExecuting");
            context.Result = new ContentResult()
            {
                Content = "Resource unavailable - header should not be set"
            };
        }

        public void OnResourceExecuted(ResourceExecutedContext context)
        {
            Console.WriteLine("GggMessage: " + GetType().FullName + ": OnResourceExecuted");
        }
    }

}