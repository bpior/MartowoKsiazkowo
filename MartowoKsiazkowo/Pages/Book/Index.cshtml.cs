using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MartowoKsiazkowo.Data;
using MartowoKsiazkowo.Encje;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace MartowoKsiazkowo.Pages.Book
{
    public class IndexModel : PageModel
    {
        private readonly MartowoKsiazkowo.Data.ApplicationDbContext _context;

        public IndexModel(MartowoKsiazkowo.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Encje.Book> Book { get; set; }

        public async Task<IActionResult> OnGetAsync(string searchString, int? bookInfoId)
        {
            var books = from b in _context.Books
                select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Tytul.Contains(searchString));
            }

            Book = await books.ToListAsync();
            return Page();
        }
    }
}



/*{
    if (_context.Books != null)
    {
        Book = await _context.Books
        .Include(b => b.Author)
        .Include(b => b.BookInfo).ToListAsync();
    }
    
    if (_context.Books == null)
    {
        return Page(); // NotFound(); //ThrownExceptionInfo("Entity set 'BibliotekaContext.Book' is null");
    }
    
    var books = from book in _context.Books select book;

    if (!String.IsNullOrEmpty(searchString))
    {
        books = books.Where(s=>s.Tytul!.Contains(searchString));
    }

    if (bookInfoId.HasValue)
    {
        books = books.Where(b => b.BookInfoId == bookInfoId);
    }


    /*
    var bookInfoList = bookInfoId.HasValue
        ? await _context.BookInfo.Select(bi => new { Id = bi.BookInfoId, Gatunek = bi.Gatunek }).ToListAsync()
        : await _context.BookInfo.Select(bi => new {Id=bi.BookInfoId, Gatunek = bi.Gatunek}).ToListAsync();
        #1#
    
    
    var bookInfoList = await _context.BookInfo.Select(bi => new {Id=bi.BookInfoId, Gatunek = bi.Gatunek}).ToListAsync();
    
//    var bookInfoList = await _context.BookInfo.Select(bi => new {Id=bi.Id, Gatunek = bi.Gatunek}).ToListAsync();
    
//            ViewData["BookInfoId"] = new SelectList(bookInfoList, "Id", "Gatunek");

//            return View(await books.Include(b => b.Author).Include(b => b.BookInfo).ToListAsync());

 //   return Page(await books.Include(b=> Author).Include(b=> BookInfo).ToListAsync());
 return Page();*/
     //   }
   // }

