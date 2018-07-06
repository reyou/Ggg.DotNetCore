using aspnetcoreapp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace aspnetcoreapp.Pages
{
    public class CreateModel : PageModel
    {
        /*The Customer property uses [BindProperty] attribute to opt in to model binding.*/
        [BindProperty]
        public Customer Customer { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Color is required")]
        public string Color { get; set; }
        private readonly AppDbContext _db;
        public CreateModel(AppDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostAsync()
        {
            /*ModelStateDictionary Class Represents the state of an attempt to bind values from an HTTP
             Request to an action method, which includes validation information.*/
            /*ModelStateDictionary.IsValid Property Gets a value that indicates whether any model state values
             in this model state dictionary is invalid or not validated.*/
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _db.Customers.Add(Customer);
            await _db.SaveChangesAsync();
            return RedirectToPage("/Index");
        }
    }
}