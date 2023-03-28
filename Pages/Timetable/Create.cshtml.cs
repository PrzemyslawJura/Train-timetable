using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ASP_DOT_NET_APP.Data;
using ASP_DOT_NET_APP.Models;

namespace ASP_DOT_NET_APP.Pages.Timetable
{
    public class CreateModel : PageModel
    {
        private readonly ASP_DOT_NET_APP.Data.ApplicationDbContext _context;

        public CreateModel(ASP_DOT_NET_APP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Rozklad_Jazdy Rozklad_Jazdy { get; set; }

        [TempData]
        public string Message { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Timetable.Add(Rozklad_Jazdy);
            await _context.SaveChangesAsync();

            Message = "Train toure created successfully";

            return RedirectToPage("./Index");
        }
    }
}
