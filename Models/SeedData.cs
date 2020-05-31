using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Cwieczenie_12.Models;

namespace Cwieczenie_12.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider) 
        {
            using (var context = new s19314Context(serviceProvider.GetRequiredService<DbContextOptions<s19314Context>>())) 
            {
                if (context.Movie.Any()) {
                    return;
                }
                context.AddRange(
                    new Movie
                    {
                        Title = "When Harry Met Sally",
                        RealeaseDate = DateTime.Parse("1989-2-12"),
                        Genre = "Romantic Comedy",
                        Price = 7.99M,
                        Rating = "R"

                    },

                    new Movie
                    {
                        Title = "Ghostbusters ",
                        RealeaseDate = DateTime.Parse("1984-3-13"),
                        Genre = "Comedy",
                        Price = 8.99M,
                        Rating = "L"
                    },

                    new Movie
                    {
                        Title = "Ghostbusters 2",
                        RealeaseDate = DateTime.Parse("1986-2-23"),
                        Genre = "Comedy",
                        Price = 9.99M,
                        Rating = "R"
                    },

                    new Movie
                    {
                        Title = "Rio Bravo",
                        RealeaseDate = DateTime.Parse("1959-4-15"),
                        Genre = "Western",
                        Price = 3.99M,
                        Rating = "Y"
                    }

                );
            
            
            }
        }
    }
}
