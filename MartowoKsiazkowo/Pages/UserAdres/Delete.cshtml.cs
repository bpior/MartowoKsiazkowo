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
    public class DeleteModel : PageModel
    {
        private readonly MartowoKsiazkowo.Data.ApplicationDbContext _context;

        public DeleteModel(MartowoKsiazkowo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public UserAddress UserAddress { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserAddress == null)
            {
                return NotFound();
            }

            var useraddress = await _context.UserAddress.FirstOrDefaultAsync(m => m.UserAddressId == id);

            if (useraddress == null)
            {
                return NotFound();
            }
            else 
            {
                UserAddress = useraddress;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.UserAddress == null)
            {
                return NotFound();
            }
            var useraddress = await _context.UserAddress.FindAsync(id);

            if (useraddress != null)
            {
                UserAddress = useraddress;
                _context.UserAddress.Remove(UserAddress);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
