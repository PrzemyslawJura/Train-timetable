using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ASP_DOT_NET_APP.Data;
using ASP_DOT_NET_APP.Models;

namespace ASP_DOT_NET_APP.Pages.Timetable
{
    public class DetailsModel : PageModel
    {
        private readonly ASP_DOT_NET_APP.Data.ApplicationDbContext _context;

        public DetailsModel(ASP_DOT_NET_APP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Rozklad_Jazdy Rozklad_Jazdy { get; set; }

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
    }
}
