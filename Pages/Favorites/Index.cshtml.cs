using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Movie_App.Data;
using Movie_App.Models;

namespace Movie_App.Pages.Favorites
{
    public class IndexModel : PageModel
    {
        private readonly Movie_App.Data.Favorite_AppContext _context;

        public IndexModel(Movie_App.Data.Favorite_AppContext context)
        {
            _context = context;
        }

        public IList<Favorite> Favorites { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Favorite != null)
            {
                Favorites = await _context.Favorite.ToListAsync();
            }
        }
    }
}
