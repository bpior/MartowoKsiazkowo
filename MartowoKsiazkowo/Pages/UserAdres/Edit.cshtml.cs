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

namespace MartowoKsiazkowo.Pages.UserAdres
{
    public class EditModel : PageModel
    {
        private readonly MartowoKsiazkowo.Data.ApplicationDbContext _context;

        public EditModel(MartowoKsiazkowo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserAddress UserAddress { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.UserAddress == null)
            {
                return NotFound();
            }

            var useraddress =  await _context.UserAddress.FirstOrDefaultAsync(m => m.UserAddressId == id);
            if (useraddress == null)
            {
                return NotFound();
            }
            UserAddress = useraddress;
           ViewData["UserId"] = new SelectList(_context.User, "UserId", "UserId");
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

            _context.Attach(UserAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserAddressExists(UserAddress.UserAddressId))
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

        private bool UserAddressExists(int id)
        {
          return _context.UserAddress.Any(e => e.UserAddressId == id);
        }
    }
}
