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
    public class UnbookModel : PageModel
    {

        private readonly ASP_DOT_NET_APP.Data.ApplicationDbContext _context;
        public UnbookModel(ASP_DOT_NET_APP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Rozklad_Jazdy Rozklad_Jazdy { get; set; }
        [BindProperty]
        public bok bookk { get; set; }
        [BindProperty]
        public IList<bok> bok { get; set; }
        [BindProperty]
        public IList<Rozklad_Jazdy> Rozklad { get; set; }
        [BindProperty]
        public int help { get; set; }
        [TempData]
        public string Message { get; set; }


        public async Task OnGetAsync(int? id)
        {
            IQueryable<string> genreQuery = from m in _context.Timetable
                                            orderby m.Name_From
                                            select m.Name_From;

            var timeT = from m in _context.Timetable
                        select m;

            var bokT = from m in _context.reservatonn
                       select m;

            Rozklad_Jazdy = await _context.Timetable.FirstOrDefaultAsync(m => m.Id == id);

            Rozklad = await timeT.ToListAsync();
            ////ToListAsync();
            bok = await bokT.ToListAsync();
        }



        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (help == 0)
            {
                return NotFound();
            }


            bookk = await _context.reservatonn.FindAsync(help);

            if (bookk != null)
            {
                _context.reservatonn.Remove(bookk);
                await _context.SaveChangesAsync();
            }

            Message = "The unbooking was successful";

            return RedirectToPage("./Index");
        }


    }
}
