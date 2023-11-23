using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataBaseContext;
using DatabaseEntityLib;

namespace StudentskaSluzba.Pages.IspitPage
{
    public class DeleteModel : PageModel
    {
        private readonly DataBaseContext.DB_Context_Class _context;

        public DeleteModel(DataBaseContext.DB_Context_Class context)
        {
            _context = context;
        }

        [BindProperty]
      public Ispit Ispit { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ispit == null)
            {
                return NotFound();
            }

            var ispit = await _context.Ispit.FirstOrDefaultAsync(m => m.ID == id);

            if (ispit == null)
            {
                return NotFound();
            }
            else 
            {
                Ispit = ispit;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Ispit == null)
            {
                return NotFound();
            }
            var ispit = await _context.Ispit.FindAsync(id);

            if (ispit != null)
            {
                Ispit = ispit;
                _context.Ispit.Remove(Ispit);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Ispiti");
        }
    }
}
