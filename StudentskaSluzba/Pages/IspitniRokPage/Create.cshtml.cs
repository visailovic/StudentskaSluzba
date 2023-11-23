﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DataBaseContext;
using DatabaseEntityLib;

namespace StudentskaSluzba.Pages.IspitniRokPage
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
            return Page();
        }

        [BindProperty]
        public IspitniRok IspitniRok { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.IspitniRok == null || IspitniRok == null)
            {
                return Page();
            }

            _context.IspitniRok.Add(IspitniRok);
            await _context.SaveChangesAsync();

            return RedirectToPage("./IspitniRokovi");
        }
    }
}
