using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace GggWebApplication.Controllers.FilterExamples
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1#using-middleware-in-the-filter-pipeline
    /// http://localhost:11781/en-en/Culture/CultureFromRouteData
    /// http://localhost:11781/fr-fr/Culture/CultureFromRouteData
    /// </summary>
    [Route("{culture}/[controller]/[action]")]
    [MiddlewareFilter(typeof(Startup.LocalizationPipeline))]
    public class CultureController : Controller
    {
        public IActionResult CultureFromRouteData()
        {
            return Content($"CurrentCulture:{CultureInfo.CurrentCulture.Name},"
                           + $"CurrentUICulture:{CultureInfo.CurrentUICulture.Name}");
        }
    }
}