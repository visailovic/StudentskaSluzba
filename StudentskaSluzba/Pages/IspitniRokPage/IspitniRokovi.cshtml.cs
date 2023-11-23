using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataBaseContext;
using DatabaseEntityLib;

namespace StudentskaSluzba.Pages.IspitniRokPage
{
    public class IspitniRokModel : PageModel
    {
        private readonly DB_Context_Class _context;

        public IspitniRokModel(DB_Context_Class context)
        {
            _context = context;
        }

        public IList<IspitniRok> IspitniRok { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.IspitniRok != null)
            {
                IspitniRok = await _context.IspitniRok.ToListAsync();
            }
        }
    }
}
