using GggWebApplication.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace GggWebApplication.Controllers.FilterExamples
{
    /// <summary>
    /// http://localhost:11781/SampleActionFilter
    /// </summary>
    public class SampleActionFilterController : Controller
    {
        [SampleActionFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
}