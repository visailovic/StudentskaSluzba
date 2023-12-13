using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DataBaseContext;
using DatabaseEntityLib;

namespace StudentskaSluzba.Pages.StudentPage
{
    public class StudentModel : PageModel
    {
        private readonly DataBaseContext.DB_Context_Class _context;

        [BindProperty]
        public string SearchText { get; set; }

        static bool reverseName = false;
        static bool reverseSurname = false;
        static bool reverseBirthday = false;

        public StudentModel(DataBaseContext.DB_Context_Class context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Student != null)
            {
                Student = await _context.Student.ToListAsync();
            }
        }
        public async void OnGetSortByName()
        {
            if (reverseName) Student = await _context.Student.OrderBy(s => s.Name).ToListAsync();
            else Student = await _context.Student.OrderByDescending(s => s.Name).ToListAsync();
            reverseName = !reverseName;
        }
        public async void OnGetSortBySurname()
        {
            if (reverseSurname) Student = await _context.Student.OrderBy(s => s.Surname).ToListAsync();
            else Student = await _context.Student.OrderByDescending(s => s.Surname).ToListAsync();
            reverseSurname = !reverseSurname;
        }
        public async void OnGetSortByDateOfBirth()
        {
            if (reverseBirthday) Student = await _context.Student.OrderBy(s => s.DateOfBirth).ToListAsync();
            else Student = await _context.Student.OrderByDescending(s => s.DateOfBirth).ToListAsync();
            reverseBirthday = !reverseBirthday;
        }
        public async void OnPost()
        {
            if (SearchText == null)
            {
                Student = await _context.Student.ToListAsync();
            }
            else
            {
                Student = await _context.Student.Where(s => EF.Functions.Like(s.Name, $"%{SearchText}%") || EF.Functions.Like(s.Surname, $"%{SearchText}%")).ToListAsync();
            }
        }
    }
}
