using Microsoft.EntityFrameworkCore;


namespace Movie_App.Data
{
    public class Favorite_AppContext : DbContext
    {
        public Favorite_AppContext(DbContextOptions<Favorite_AppContext> options) 
            : base(options)
        {
        }
        public DbSet<Movie_App.Models.Favorite> Favorite { get; set; } = default!;
    }
}
