using aspnetcoreapp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace aspnetcoreapp.Pages
{
    public class TempDataExampleModel : PageModel
    {
        private readonly AppDbContext _db;

        /// <summary>
        /// This property stores data until it's read. The Keep and Peek methods can be used
        /// to examine the data without deletion. TempData is useful for redirection,
        /// when data is needed for more than a single request.
        /// </summary>
        [TempData]
        public string Message { get; set; }

        public TempDataExampleModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
    }
}