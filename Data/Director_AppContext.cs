using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movie_App.Models;

namespace Movie_App.Data
{
    public class Director_AppContext : DbContext
    {
        public Director_AppContext (DbContextOptions<Director_AppContext> options)
            : base(options)
        {
        }

        public DbSet<Movie_App.Models.Director> Director { get; set; } = default!;
    }
}
