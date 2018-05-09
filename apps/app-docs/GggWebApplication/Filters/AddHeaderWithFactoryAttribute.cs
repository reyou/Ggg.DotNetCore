using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace GggWebApplication.Filters
{
    // IFilterFactory Interface: An interface for filter metadata which can
    // create an instance of an executable filter
    public class AddHeaderWithFactoryAttribute : Attribute, IFilterFactory
    {
        // Implement IFilterFactory
        // IFilterMetadata Interface: Marker interface for filters handled in the MVC request pipeline
        // IServiceProvider Interface: Defines a mechanism for retrieving a service
        // object; that is, an object that provides custom support to other objects
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return new InternalAddHeaderFilter();
        }

        // IResultFilter Interface: A filter that surrounds execution of
        // action results successfully returned from an action
        private class InternalAddHeaderFilter : IResultFilter
        {
            // ResultExecutingContext Class: A context for result filters, specifically
            // OnResultExecuting(ResultExecutingContext) and
            // OnResultExecutionAsync(ResultExecutingContext, ResultExecutionDelegate) calls
            public void OnResultExecuting(ResultExecutingContext context)
            {
                context.HttpContext.Response.Headers.Add("Internal", new[] { "Header Added" });
            }

            public void OnResultExecuted(ResultExecutedContext context)
            {
            }
        }

        public bool IsReusable => false;
    }

}
