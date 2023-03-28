using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASP_DOT_NET_APP.Data;
using ASP_DOT_NET_APP.Models;

namespace ASP_DOT_NET_APP.Pages.Timetable
{
    public class BookModel : PageModel
    {
        private readonly ASP_DOT_NET_APP.Data.ApplicationDbContext _context;

        public BookModel(ASP_DOT_NET_APP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rozklad_Jazdy Rozklad_Jazdy { get; set; }

        [BindProperty]
        public bok bookk { get; set; }

        [TempData]
        public string Message { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {


            //    if (!ModelState.IsValid)
            //    {
            //       return Page();
            //  }

            bookk.Book_Id = Rozklad_Jazdy.Id;
            _context.reservatonn.Add(bookk);
            await _context.SaveChangesAsync();

            Message = "The booking was successful";

            return RedirectToPage("./Index");
        }
    }

}

