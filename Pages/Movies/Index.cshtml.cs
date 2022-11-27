using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Movie_App.Data;
using Movie_App.Models;

namespace Movie_App.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly Movie_App.Data.Movie_AppContext _context;
        private readonly IConfiguration Configuration;
        public string CurrentFilter { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        public SelectList? Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }


        public IndexModel(Movie_App.Data.Movie_AppContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public PaginatedList<Movie> Movies { get; set; } = default!;

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


            IQueryable<Movie> movieIQ = from s in _context.Movie
                                             select s;
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;

            var movies = from m in _context.Movie
                         select m;

            CurrentFilter = searchString;


            if (!string.IsNullOrEmpty(SearchString))
            {
                movieIQ = movieIQ.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre).OrderBy(x => x.Id);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            var pageSize = Configuration.GetValue("PageSize", 4);
            Movies = await PaginatedList<Movie>.CreateAsync(
                movieIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }

        
    }
}