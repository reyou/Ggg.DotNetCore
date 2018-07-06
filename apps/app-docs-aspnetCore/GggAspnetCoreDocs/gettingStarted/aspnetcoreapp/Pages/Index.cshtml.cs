using aspnetcoreapp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace aspnetcoreapp.Pages
{
    public class IndexModel : PageModel
    {
        public IList<Customer> Customers { get; private set; }
        private readonly AppDbContext _db;
        public void OnHead()
        {
            HttpContext.Response.Headers.Add("HandledBy", "Handled by OnHead!");
        }

        public IndexModel(AppDbContext db)
        {
            _db = db;
        }

        public async Task OnGetAsync()
        {
            /*AsNoTracking(IQueryable) Returns a new query where the change tracker
             will not track any of the entities that are returned. If the entity 
             instances are modified, this will not be detected by the change tracker 
             and SaveChanges() will not persist those changes to the database.*/
            Customers = await _db.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            Customer contact = await _db.Customers.FindAsync(id);

            if (contact != null)
            {
                _db.Customers.Remove(contact);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}
