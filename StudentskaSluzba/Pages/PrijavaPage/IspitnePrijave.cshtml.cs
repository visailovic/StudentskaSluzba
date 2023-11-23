using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataBaseContext;
using DatabaseEntityLib;

namespace StudentskaSluzba.Pages.PrijavaPage
{
    public class PrijavaModel : PageModel
    {
        private readonly DataBaseContext.DB_Context_Class _context;

        public PrijavaModel(DataBaseContext.DB_Context_Class context)
        {
            _context = context;
        }

        public IList<Prijava> Prijava { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Prijava != null)
            {
                Prijava = await _context.Prijava
                .Include(p => p.Ispit)
                .Include(p => p.IspitniRok)
                .Include(p => p.Student).ToListAsync();
            }
        }
    }
}
