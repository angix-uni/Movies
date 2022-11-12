using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movie_App.Models;

namespace Movie_App.Data
{
    public class Movie_AppContext : DbContext
    {
        public Movie_AppContext (DbContextOptions<Movie_AppContext> options)
            : base(options)
        {
        }

        public DbSet<Movie_App.Models.Movie> Movie { get; set; } = default!;
    }
}
