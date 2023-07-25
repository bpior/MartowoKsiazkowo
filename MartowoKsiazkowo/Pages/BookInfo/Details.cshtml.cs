using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MartowoKsiazkowo.Data;
using MartowoKsiazkowo.Encje;

namespace MartowoKsiazkowo.Pages.BookInfo
{
    public class DetailsModel : PageModel
    {
        private readonly MartowoKsiazkowo.Data.ApplicationDbContext _context;

        public DetailsModel(MartowoKsiazkowo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Encje.BookInfo BookInfo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.BookInfo == null)
            {
                return NotFound();
            }

            var bookinfo = await _context.BookInfo.FirstOrDefaultAsync(m => m.BookInfoId == id);
            if (bookinfo == null)
            {
                return NotFound();
            }
            else 
            {
                BookInfo = bookinfo;
            }
            return Page();
        }
    }
}
