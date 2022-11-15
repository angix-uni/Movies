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
    public class IndexModel : PageModel
    {
        private readonly Movie_App.Data.Director_AppContext _context;

        public IndexModel(Movie_App.Data.Director_AppContext context)
        {
            _context = context;
        }

        public IList<Director> Director { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Director != null)
            {
                Director = await _context.Director.ToListAsync();
            }
        }
    }
}
