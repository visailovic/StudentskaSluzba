﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataBaseContext;
using DatabaseEntityLib;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using System.IO;

namespace StudentskaSluzba.Pages.StudentPage
{
    public class EditModel : PageModel
    {
        private readonly DataBaseContext.DB_Context_Class _context;
        private IWebHostEnvironment _environment;

        public EditModel(DataBaseContext.DB_Context_Class context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        [BindProperty]
        public Student Student { get; set; } = default!;
        
        [BindProperty]
        public IFormFile Upload { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Student == null)
            {
                return NotFound();
            }

            var student =  await _context.Student.FirstOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            Student = student;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var file = Path.Combine(_environment.ContentRootPath, "wwwroot\\images", Upload.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);

                Student.Image = Upload.FileName;
            }
            _context.Attach(Student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Studenti");
        }

        private bool StudentExists(int id)
        {
          return (_context.Student?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
