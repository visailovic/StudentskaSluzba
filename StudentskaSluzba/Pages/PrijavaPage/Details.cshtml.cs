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
    public class DetailsModel : PageModel
    {
        private readonly DataBaseContext.DB_Context_Class _context;

        public DetailsModel(DataBaseContext.DB_Context_Class context)
        {
            _context = context;
        }

      public Prijava Prijava { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Prijava == null)
            {
                return NotFound();
            }

            var prijava = await _context.Prijava.FirstOrDefaultAsync(m => m.ID == id);
            if (prijava == null)
            {
                return NotFound();
            }
            else 
            {
                Prijava = prijava;
            }
            return Page();
        }
    }
}
