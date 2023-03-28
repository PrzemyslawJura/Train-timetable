using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ASP_DOT_NET_APP.Data;
using ASP_DOT_NET_APP.Models;

namespace ASP_DOT_NET_APP.Pages.Timetable
{
    public class EditModel : PageModel
    {
        private readonly ASP_DOT_NET_APP.Data.ApplicationDbContext _context;

        public EditModel(ASP_DOT_NET_APP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rozklad_Jazdy Rozklad_Jazdy { get; set; }

        [TempData]
        public string Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Rozklad_Jazdy = await _context.Timetable.FirstOrDefaultAsync(m => m.Id == id);

            if (Rozklad_Jazdy == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Rozklad_Jazdy).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Rozklad_JazdyExists(Rozklad_Jazdy.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            Message = "Train toure updated successfully";

            return RedirectToPage("./Index");
        }

        private bool Rozklad_JazdyExists(int id)
        {
            return _context.Timetable.Any(e => e.Id == id);
        }
    }
}
