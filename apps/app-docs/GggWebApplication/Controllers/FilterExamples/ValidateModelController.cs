using GggWebApplication.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace GggWebApplication.Controllers.FilterExamples
{
    /// <summary>
    /// http://localhost:11781/ValidateModel
    /// </summary>
    [ValidateModel]
    public class ValidateModelController : Controller
    {
        public IActionResult Index()
        {
            return Content("ValidateModelController is running.");
        }
    }
}
