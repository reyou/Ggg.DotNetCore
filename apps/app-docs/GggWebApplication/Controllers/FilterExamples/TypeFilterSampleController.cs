using GggWebApplication.Filters;
using Microsoft.AspNetCore.Mvc;

namespace GggWebApplication.Controllers.FilterExamples
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/filters?view=aspnetcore-2.1#dependency-injection
    /// TypeFilterAttribute is similar to ServiceFilterAttribute, but its type
    /// isn't resolved directly from the DI container. It instantiates the type
    /// by using Microsoft.Extensions.DependencyInjection.ObjectFactory.
    /// http://localhost:11781/TypeFilterSample/Hi
    /// </summary>
    public class TypeFilterSampleController : Controller
    {
        [TypeFilter(typeof(AddHeaderAttribute), Arguments = new object[] { "Author", "Steve Smith (@ardalis)" })]
        public IActionResult Hi(string name)
        {
            return Content($"Hi {name}");
        }

    }
}
