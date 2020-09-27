using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty] //get the property when OnPost is invoked automatically
        public Book Book { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {                       //iactionresult to redirect to new page, onPost() is the handler name

            if (ModelState.IsValid) //ModelState helps in making sure all the required fields are entered correctly etc.
            {
                await _db.Book.AddAsync(Book); //adding the book object to the database
                await _db.SaveChangesAsync();//to push changes to database
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
