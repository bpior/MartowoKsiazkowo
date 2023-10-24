using MartowoKsiazkowo.Data;
using MartowoKsiazkowo.Encje;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

public class Test : PageModel
{
    private readonly ApplicationDbContext _context;

    
    

    [BindProperty]
    public Book Book { get; set; }

    [BindProperty]
    public IFormFile ImageFile { get; set; }

    public Test(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        ViewData["AuthorId"] = new SelectList(_context.Author, "FullAutorName", "AuthorId");
        ViewData["BookInfoId"] = new SelectList(_context.BookInfo, "Gatunek", "BookInfoId");
        return Page();
    }


    
    
    /*public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (ImageFile != null && ImageFile.Length > 0)
        {
            using (var memoryStream = new MemoryStream())
            {
                await ImageFile.CopyToAsync(memoryStream);
                Book.Miniatura = memoryStream.ToArray();
            }
        }*/
    
    
    
    /*public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        if (ImageFile != null && ImageFile.Length > 0)
        {
            using (var memoryStream = new MemoryStream())
            {
                await ImageFile.CopyToAsync(memoryStream);
                Book.Miniatura = memoryStream.ToArray();
            }
        }*/
    
    public async Task<IActionResult> OnPostAsync()
    {
        /*if (!ModelState.IsValid)
        {
            return Page();
        }*/

        if (ImageFile != null && ImageFile.Length > 0)
        {
            using (var memoryStream = new MemoryStream())
            {
                await ImageFile.CopyToAsync(memoryStream);
                Book.ImageData = memoryStream.ToArray();
                Book.ImageMimeType = ImageFile.ContentType; // Ustalamy typ MIME obrazu
            }
        }
    

        _context.Books.Add(Book);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}








/*using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MartowoKsiazkowo.Pages;

public class Test : PageModel
{
    public void OnGet()
    {
        
    }
}*/