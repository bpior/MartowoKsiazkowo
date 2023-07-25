using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MartowoKsiazkowo.Data;
using MartowoKsiazkowo.Encje;

namespace MartowoKsiazkowo.Pages.BookInfo
{
    public class EditModel : PageModel
    {
        private readonly MartowoKsiazkowo.Data.ApplicationDbContext _context;

        public EditModel(MartowoKsiazkowo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Encje.BookInfo BookInfo { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookInfo == null)
            {
                return NotFound();
            }

            var bookinfo =  await _context.BookInfo.FirstOrDefaultAsync(m => m.BookInfoId == id);
            if (bookinfo == null)
            {
                return NotFound();
            }
            BookInfo = bookinfo;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BookInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookInfoExists(BookInfo.BookInfoId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BookInfoExists(int id)
        {
          return _context.BookInfo.Any(e => e.BookInfoId == id);
        }
    }
}
