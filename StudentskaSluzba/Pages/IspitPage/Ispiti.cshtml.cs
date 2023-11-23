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
    public class IndexModel : PageModel
    {
        private readonly DB_Context_Class _context;

        public IndexModel(DB_Context_Class context)
        {
            _context = context;
        }

        public IList<Ispit> Ispit { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Ispit != null)
            {
                Ispit = await _context.Ispit.ToListAsync();
            }
        }
    }
}
