using BookListRazorWebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookListRazorWebApp.Pages.BookList    
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> Books { get; set; }

        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var BookFromDb = await _db.Book.FindAsync(id);

            if (BookFromDb == null)
            {
                return NotFound();
            }

            _db.Remove(BookFromDb);
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}
