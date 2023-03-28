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
    public class IndexModel : PageModel
    {
        private readonly ASP_DOT_NET_APP.Data.ApplicationDbContext _context;

        public IndexModel(ASP_DOT_NET_APP.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Rozklad_Jazdy> Rozklad_Jazdy { get;set; }

        public IList<bok> bok { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString2 { get; set; }

        public string login = "default";

        [TempData]
        public string Message { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from m in _context.Timetable
                                            orderby m.Name_From
                                            select m.Name_From;

            var timeT = from m in _context.Timetable
                        select m;

            var bokT = from m in _context.reservatonn
                        select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                timeT = timeT.Where(s => s.Name_From.Contains(SearchString));
            }
            if (!string.IsNullOrEmpty(SearchString2))
            {
                timeT = timeT.Where(s => s.Name_To.Contains(SearchString2));
            }
            Rozklad_Jazdy = await timeT.ToListAsync();
            //ToListAsync();
            bok = await bokT.ToListAsync();
        }

        public virtual void Book_click(Object sender, EventArgs e)
        {

        }


    }
}
