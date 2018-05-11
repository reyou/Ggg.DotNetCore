using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace GggWebApplication.Attributes
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1#exception-filters
    /// </summary>
    /*Exception filters implement either the IExceptionFilter or IAsyncExceptionFilter
     interface. They can be used to implement common error handling policies 
     for an app.*/
    // ExceptionFilterAttribute Class
    // An abstract filter that runs asynchronously after an action has thrown an Exception.
    // Subclasses must override OnException(ExceptionContext) or OnExceptionAsync(ExceptionContext) but not both
    public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
    {
        // IHostingEnvironment Interface
        // Provides information about the web hosting environment an application is running in.
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IModelMetadataProvider _modelMetadataProvider;
        public CustomExceptionFilterAttribute(IHostingEnvironment hostingEnvironment, IModelMetadataProvider modelMetadataProvider)
        {
            _hostingEnvironment = hostingEnvironment;
            _modelMetadataProvider = modelMetadataProvider;
        }
        // A context for exception filters i.e. IExceptionFilter and IAsyncExceptionFilter
        // implementations
        public override void OnException(ExceptionContext context)
        {
            if (!_hostingEnvironment.IsDevelopment())
            {
                // do nothing
                return;
            }
            ViewResult result = new ViewResult { ViewName = "CustomError" };
            result.ViewData = new ViewDataDictionary(_modelMetadataProvider, context.ModelState);
            result.ViewData.Add("Exception", context.Exception);
            // TODO: Pass additional detailed data via ViewData
            context.Result = result;
        }

    }
}
