using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataBaseContext;
using DatabaseEntityLib;

namespace StudentskaSluzba.Pages.PrijavaPage
{
    public class CreateModel : PageModel
    {
        private readonly DataBaseContext.DB_Context_Class _context;

        public CreateModel(DataBaseContext.DB_Context_Class context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["IspitID"] = new SelectList(_context.Ispit, "ID", "Name");
            ViewData["IspitniRokID"] = new SelectList(_context.IspitniRok, "ID", "Name");
            ViewData["StudentID"] = new SelectList(_context.Student, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Prijava Prijava { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (/*!ModelState.IsValid ||*/ _context.Prijava == null || Prijava == null)
            {
                return Page();
            }

            _context.Prijava.Add(Prijava);
            await _context.SaveChangesAsync();

            return RedirectToPage("./IspitnePrijave");
        }
    }
}
