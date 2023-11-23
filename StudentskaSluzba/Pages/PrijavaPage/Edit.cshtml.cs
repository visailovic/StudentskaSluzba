using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataBaseContext;
using DatabaseEntityLib;

namespace StudentskaSluzba.Pages.PrijavaPage
{
    public class EditModel : PageModel
    {
        private readonly DataBaseContext.DB_Context_Class _context;

        public EditModel(DataBaseContext.DB_Context_Class context)
        {
            _context = context;
        }

        [BindProperty]
        public Prijava Prijava { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Prijava == null)
            {
                return NotFound();
            }

            var prijava =  await _context.Prijava
                .Include(p => p.Ispit)
                .Include(p => p.IspitniRok)
                .Include(p => p.Student)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (prijava == null)
            {
                return NotFound();
            }
            Prijava = prijava;
           ViewData["IspitID"] = new SelectList(_context.Ispit, "ID", "Name");
           ViewData["IspitniRokID"] = new SelectList(_context.IspitniRok, "ID", "Name");
           ViewData["StudentID"] = new SelectList(_context.Student, "ID", "Name");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
/*            Prijava = await _context.Prijava
    .Include(p => p.Ispit)
    .Include(p => p.IspitniRok)
    .Include(p => p.Student)
    .FirstOrDefaultAsync(m => m.ID == Prijava.ID);*/

            ModelState.ClearValidationState(nameof(Prijava));
            TryValidateModel(Prijava, nameof(Prijava));

/*            if (!ModelState.IsValid)
            {
                return Page();
            }*/

            _context.Attach(Prijava).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrijavaExists(Prijava.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./IspitnePrijave");
        }

        private bool PrijavaExists(int id)
        {
          return (_context.Prijava?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
