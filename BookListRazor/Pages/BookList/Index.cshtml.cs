using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IEnumerable<Book> Books { get; set; } //IEnumerable is an interface used for lists or classes that allows for iteration over even anonynmous types
        //IEnumerable is capable of holding tasks VERY IMPORTANT

        public async Task OnGet() //async task is used as the method is asynchronous
        { //when getting the page, put all the books into an ienumerable list so that it can be used by html
            Books = await _db.Book.ToListAsync(); //await allows for aysynchronous,
            //                gets from DbSet applicationdbcontext
            //                ToListAsync() helps in retrieving the books from database
        }

        public async Task <IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Book.FindAsync(id); //FindAsync is method of DbSet class

            if (book == null)
            {
                return NotFound();
            }

            _db.Book.Remove(book);

            await _db.SaveChangesAsync();

            return RedirectToPage("Index"); //to make it reload
        }
    }
}
