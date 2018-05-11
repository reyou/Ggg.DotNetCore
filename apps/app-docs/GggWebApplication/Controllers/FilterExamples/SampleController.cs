using GggWebApplication.Filters;
using GggWebApplication.Filters.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace GggWebApplication.Controllers.FilterExamples
{
    /// <summary>
    /// http://localhost:11781/sample
    /// http://localhost:11781/sample/SomeResource
    /// </summary>
    [AddHeader("Author", "Steve Smith @ardalis")]
    public class SampleController : Controller
    {
        public IActionResult Index()
        {
            return Content("Examine the headers using developer tools.");
        }

        [ShortCircuitingResourceFilter]
        public IActionResult SomeResource()
        {
            return Content("Successful access to resource - header should be set.");
        }

    }
}
