using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MartowoKsiazkowo.Data;
using MartowoKsiazkowo.Encje;

namespace MartowoKsiazkowo.Pages.BookUsers
{
    public class DeleteModel : PageModel
    {
        private readonly MartowoKsiazkowo.Data.ApplicationDbContext _context;

        public DeleteModel(MartowoKsiazkowo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public BookUser BookUser { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookUser == null)
            {
                return NotFound();
            }

            var bookuser = await _context.BookUser.FirstOrDefaultAsync(m => m.BookUserId == id);

            if (bookuser == null)
            {
                return NotFound();
            }
            else 
            {
                BookUser = bookuser;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.BookUser == null)
            {
                return NotFound();
            }
            var bookuser = await _context.BookUser.FindAsync(id);

            if (bookuser != null)
            {
                BookUser = bookuser;
                _context.BookUser.Remove(BookUser);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
