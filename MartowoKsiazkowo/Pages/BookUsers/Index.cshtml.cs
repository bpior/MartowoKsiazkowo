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
    public class IndexModel : PageModel
    {
        private readonly MartowoKsiazkowo.Data.ApplicationDbContext _context;

        public IndexModel(MartowoKsiazkowo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<BookUser> BookUser { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.BookUser != null)
            {
                BookUser = await _context.BookUser
                .Include(b => b.Book)
                .Include(b => b.User).ToListAsync();
            }
        }
    }
}
