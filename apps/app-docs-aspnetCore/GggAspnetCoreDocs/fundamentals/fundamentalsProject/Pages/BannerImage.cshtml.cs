using System.IO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace fundamentalsProject.Pages
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-2.1&tabs=aspnetcore2x#static-file-authorization
    /// http://localhost:50312/bannerimage
    /// </summary>
    public class BannerImageModel : PageModel
    {
        [Authorize]
        public IActionResult OnGet()
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(),
                "MyStaticFiles", "images", "banner.png");
            // http://localhost:50312/bannerimage
            return PhysicalFile(file, "image/png");
        }
    }
}