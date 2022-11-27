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
    public class IndexModel : PageModel
    {
        private readonly Movie_App.Data.Director_AppContext _context;
        private readonly IConfiguration Configuration;
        public string CurrentFilter { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }

        public IndexModel(Movie_App.Data.Director_AppContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public PaginatedList<Director> Directors { get;set; } = default!;

        public async Task OnGetAsync(string currentFilter, int? pageIndex, string searchString)
        {
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IQueryable<Director> directorIQ = from s in _context.Director
                                        select s;

            CurrentFilter = searchString;


            if (!string.IsNullOrEmpty(SearchString))
            {
                directorIQ = directorIQ.Where(s => s.Surname.Contains(SearchString));
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Directors = await PaginatedList<Director>.CreateAsync(
                directorIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
