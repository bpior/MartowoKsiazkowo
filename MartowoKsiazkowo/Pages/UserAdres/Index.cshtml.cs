using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MartowoKsiazkowo.Data;
using MartowoKsiazkowo.Encje;

namespace MartowoKsiazkowo.Pages.UserAdres
{
    public class IndexModel : PageModel
    {
        private readonly MartowoKsiazkowo.Data.ApplicationDbContext _context;

        public IndexModel(MartowoKsiazkowo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<UserAddress> UserAddress { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.UserAddress != null)
            {
                UserAddress = await _context.UserAddress
                .Include(u => u.User).ToListAsync();
            }
        }
    }
}
