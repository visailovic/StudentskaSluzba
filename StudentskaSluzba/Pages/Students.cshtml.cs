using DataBaseContext;
using DatabaseEntityLib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace StudentskaSluzba.Pages
{
    public class StudentsModel : PageModel
    {
        private DB_Context_Class db;
        public string searchstring;

        static bool reverseID = false;
        static bool reverseName = false;
        static bool reverseSurname = false;
        static bool reverseBirthday = false;

        public IEnumerable<Student> Students { get; set; }

        [BindProperty]
        public string SearchText { get; set; }

        public StudentsModel(DB_Context_Class db)
        {
            this.db = db;
        }

        public void OnGet()
        {
            Students = db.Student.ToList();
        }

        public void OnPost()
        {
            if (SearchText == null)
            {
                Students = db.Student.ToList();
            }
            else
            {
                Students = db.Student.Where(s => EF.Functions.Like(s.Name, $"%{SearchText}%") || EF.Functions.Like(s.Surname, $"%{SearchText}%")).ToList();
            }
        }

        public void OnGetSortByID()
        {
            if(reverseID)   Students = db.Student.OrderBy(s => s.ID);
            else            Students = db.Student.OrderByDescending(s => s.ID);
            reverseID = !reverseID;
        }
        public void OnGetSortByName()
        {
            if (reverseName)    Students = db.Student.OrderBy(s => s.Name);
            else                Students = db.Student.OrderByDescending(s => s.Name);
            reverseName = !reverseName;
        }
        public void OnGetSortBySurname()
        {
            if (reverseSurname) Students = db.Student.OrderBy(s => s.Surname);
            else                Students = db.Student.OrderByDescending(s => s.Surname);
            reverseSurname = !reverseSurname;
        }
        public void OnGetSortByBirthday()
        {
            if (reverseBirthday)    Students = db.Student.OrderBy(s => s.DateOfBirth);
            else                    Students = db.Student.OrderByDescending(s => s.DateOfBirth);
            reverseBirthday = !reverseBirthday;
        }
    }
}
