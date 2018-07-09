using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcoreapp.Pages
{
    public class AboutModel : PageModel
    {
        /// <summary>
        /// Properties on controllers or Razor Page models decorated with [ViewData]
        /// have their values stored and loaded from the ViewDataDictionary.
        /// </summary>
        [ViewData]
        public string Title { get; } = "In the following example, the AboutModel contains a Title property";

        public string Message { get; set; }

        public void OnGet()
        {
            Message = "Your application description page.";
        }
    }
}
