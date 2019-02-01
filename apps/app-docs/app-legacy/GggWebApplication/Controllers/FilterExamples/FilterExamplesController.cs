using Microsoft.AspNetCore.Mvc;

namespace GggWebApplication.Controllers.FilterExamples
{
    /// <summary>
    /// Filters in ASP.NET Core MVC allow you to run code before or
    /// after specific stages in the request processing pipeline
    /// https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1
    /// https://github.com/aspnet/Docs/tree/master/aspnetcore/mvc/controllers/filters/sample
    /// </summary>
    public class FilterExamplesController : Controller
    {
        // GET: FilterExamples
        public ActionResult Index()
        {
            return View();
        }

    }
}