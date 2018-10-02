#region snippet1
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace PageFilter.Filters
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/razor-pages/filter?view=aspnetcore-2.1#implement-razor-page-filters-globally
    /// </summary>
    public class SampleAsyncPageFilter : IAsyncPageFilter
    {
        private readonly ILogger _logger;

        public SampleAsyncPageFilter(ILogger logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// OnPageHandlerSelectionAsync : Called asynchronously after the handler
        /// method has been selected, but before model binding occurs.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public async Task OnPageHandlerSelectionAsync(
                                            PageHandlerSelectedContext context)
        {
            _logger.LogDebug("Global OnPageHandlerSelectionAsync called.");
            await Task.CompletedTask;
        }

        /// <summary>
        /// OnPageHandlerExecutionAsync : Called asynchronously before the handler
        /// method is invoked, after model binding is complete.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public async Task OnPageHandlerExecutionAsync(
                                            PageHandlerExecutingContext context,
                                            PageHandlerExecutionDelegate next)
        {
            _logger.LogDebug("Global OnPageHandlerExecutionAsync called.");
            await next.Invoke();
        }
    }
}
#endregion