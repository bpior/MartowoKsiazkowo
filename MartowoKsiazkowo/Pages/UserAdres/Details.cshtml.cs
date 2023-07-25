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
    public class DetailsModel : PageModel
    {
        private readonly MartowoKsiazkowo.Data.ApplicationDbContext _context;

        public DetailsModel(MartowoKsiazkowo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}
