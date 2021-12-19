using BooksStore.DAL.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.DAL.Seeders
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDb(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BookStoreDb>>()))
            {
                // Look for any movies.
                if (context.Categories.Any())
                {
                    return;   // DB has been seeded
                }

                context.Categories.AddRange(
                    new Category
                    {
                        CategoryName = "Fantasy"
                    },
                     new Category
                     {
                         CategoryName = "Classics"
                     },

                     new Category
                     {
                         CategoryName = "Comic Book or Graphic Novel"
                     },

                     new Category
                     {
                         CategoryName = "Literary Fiction"
                     },

                      new Category
                      {
                          CategoryName = "Horror"
                      }

                );
                context.SaveChanges();
            }
        }
    }
}
