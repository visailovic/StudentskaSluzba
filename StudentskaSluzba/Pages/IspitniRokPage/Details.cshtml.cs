using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataBaseContext;
using DatabaseEntityLib;
using System.Collections.ObjectModel;

namespace StudentskaSluzba.Pages.IspitniRokPage
{
    public class DetailsModel : PageModel
    {
        private readonly DataBaseContext.DB_Context_Class _context;

        public DetailsModel(DataBaseContext.DB_Context_Class context)
        {
            _context = context;
        }

        public IspitniRok IspitniRok { get; set; } = default!;
        public IList<Prijava> Prijave = new List<Prijava>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.IspitniRok == null)
            {
                return NotFound();
            }

            var ispitnirok = await _context.IspitniRok.Include(r => r.IspitnePrijave).FirstOrDefaultAsync(m => m.ID == id);
            var prijave = await _context.Prijava.Include(p => p.Student).Include(p => p.IspitniRok).Include(p => p.Ispit).Where(p => p.IspitniRokID == id).ToListAsync();

            if (ispitnirok == null)
            {
                return NotFound();
            }
            else 
            {
                IspitniRok = ispitnirok;
                Prijave = prijave;
            }
            return Page();
        }
    }
}
