using GggWebApplication.Filters.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace GggWebApplication.Controllers.FilterExamples
{
    public class HeaderSecurityController : Controller
    {
        /// <summary>
        /// http://localhost:11781/HeaderSecurity
        /// </summary>
        /// <returns></returns>
        [HeaderSecurityFilter]
        public ActionResult Index()
        {
            return View();
        }
    }
}