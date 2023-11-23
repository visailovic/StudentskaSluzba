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
    public class DeleteModel : PageModel
    {
        private readonly DataBaseContext.DB_Context_Class _context;

        public DeleteModel(DataBaseContext.DB_Context_Class context)
        {
            _context = context;
        }

        [BindProperty]
        public IspitniRok IspitniRok { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.IspitniRok == null)
            {
                return NotFound();
            }

            var ispitnirok = await _context.IspitniRok.FirstOrDefaultAsync(m => m.ID == id);

            if (ispitnirok == null)
            {
                return NotFound();
            }
            else 
            {
                IspitniRok = ispitnirok;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.IspitniRok == null)
            {
                return NotFound();
            }
            var ispitnirok = await _context.IspitniRok.FindAsync(id);

            if (ispitnirok != null)
            {
                IspitniRok = ispitnirok;
                _context.IspitniRok.Remove(IspitniRok);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./IspitniRokovi");
        }
    }
}
