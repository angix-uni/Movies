using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Movie_App.Data;
using Movie_App.Models;

namespace Movie_App.Pages.Directors
{
    public class DetailsModel : PageModel
    {
        private readonly Movie_App.Data.Director_AppContext _context;

        public DetailsModel(Movie_App.Data.Director_AppContext context)
        {
            _context = context;
        }

      public Director Director { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Director == null)
            {
                return NotFound();
            }

            var director = await _context.Director.FirstOrDefaultAsync(m => m.Id == id);
            if (director == null)
            {
                return NotFound();
            }
            else 
            {
                Director = director;
            }
            return Page();
        }
    }
}
