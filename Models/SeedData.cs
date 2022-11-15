using Microsoft.EntityFrameworkCore;
using Movie_App.Data;

namespace Movie_App.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Movie_AppContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Movie_AppContext>>()))
            {
                if (context == null || context.Movie == null)
                {
                    throw new ArgumentNullException("Null RazorPagesMovieContext");
                }

                // Look for any movies.
                if (context.Movie.Any())
                {
                    return;   // DB has been seeded
                }

                context.Movie.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M,
                        Rating = "R"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M,
                        Rating = "G"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M,
                        Rating = "G"
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        Rating = "NA"
                    }
                );
                context.SaveChanges();
            }
            //using (var context = new Director_AppContext(
            //   serviceProvider.GetRequiredService<
            //       DbContextOptions<Director_AppContext>>()))
            //{
            //    if (context == null || context.Director == null)
            //    {
            //        throw new ArgumentNullException("Null RazorPagesDirecotrContext");
            //    }

            //    // Look for any movies.
            //    if (context.Director.Any())
            //    {
            //        return;   // DB has been seeded
            //    }

            //    context.Director.AddRange(
            //        new Director
            //        {
            //            Name = "Roman",
            //            Surname = "Polański",
            //            Age = 12,
            //            Award = "None"
            //        }

                    
            //    );
            //    context.SaveChanges();
            //}
        }
    }
}
