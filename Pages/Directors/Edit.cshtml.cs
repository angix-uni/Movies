using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Movie_App.Data;
using Movie_App.Models;

namespace Movie_App.Pages.Directors
{
    public class EditModel : PageModel
    {
        private readonly Movie_App.Data.Director_AppContext _context;

        public EditModel(Movie_App.Data.Director_AppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Director Director { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Director == null)
            {
                return NotFound();
            }

            var director =  await _context.Director.FirstOrDefaultAsync(m => m.Id == id);
            if (director == null)
            {
                return NotFound();
            }
            Director = director;
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

            _context.Attach(Director).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorExists(Director.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DirectorExists(int id)
        {
          return _context.Director.Any(e => e.Id == id);
        }
    }
}
