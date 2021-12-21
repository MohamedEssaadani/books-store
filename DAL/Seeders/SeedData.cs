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
                        CategoryName = "Autobiography"
                    },
                    new Category
                     {
                         CategoryName = "Romance"
                     },

                    new Category
                     {
                         CategoryName = "Teen & Young Adult"
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




                context.Authors.AddRange(
                     new Author
                     {
                          AuthorName = "Dr. A.P.J. Abdul Kalam"
                     },
                     new Author
                     {
                         AuthorName = "Lynsay Sands"
                     },
                     new Author
                      {
                          AuthorName = "Garth Nix"
                     },
                      new Author
                       {
                           AuthorName = "Insight Editions"
                      }

                );
                context.SaveChanges();


                context.Books.AddRange(
                    new Book
                    {
                        BookName = "Wings of Fire",
                        Author = context.Authors.SingleOrDefault(x => x.AuthorId == 1),
                        AuthorId = context.Authors.SingleOrDefault(x => x.AuthorId == 1).AuthorId,
                        Category = context.Categories.SingleOrDefault(x => x.CategoryId == 1),
                        CategoryId = context.Categories.SingleOrDefault(x => x.CategoryId == 1).CategoryId,
                        Price = 37.33,
                        ReleaseDate = new DateTime(2015, 12, 31),

                    },
                     new Book
                     {
                         BookName = "Mile High with a Vampire [Large Print]",
                         Author = context.Authors.SingleOrDefault(x => x.AuthorId == 2),
                         AuthorId = context.Authors.SingleOrDefault(x => x.AuthorId == 2).AuthorId,
                         Category = context.Categories.SingleOrDefault(x => x.CategoryId == 2),
                         CategoryId = context.Categories.SingleOrDefault(x => x.CategoryId == 2).CategoryId,
                         Price = 49,
                         ReleaseDate = new DateTime(1998, 01, 18),

                     },
                      new Book
                      {
                          BookName = "Terciel & Elinor",
                          Author = context.Authors.SingleOrDefault(x => x.AuthorId == 3),
                          AuthorId = context.Authors.SingleOrDefault(x => x.AuthorId == 3).AuthorId,
                          Category = context.Categories.SingleOrDefault(x => x.CategoryId == 2),
                          CategoryId = context.Categories.SingleOrDefault(x => x.CategoryId == 2).CategoryId,
                          Price = 39.12,
                          ReleaseDate = new DateTime(2000, 10, 01),


                      },
                       new Book
                       {
                           BookName = "Harry Potter: Holiday Magic: The Official Advent Calendar",
                           Author = context.Authors.SingleOrDefault(x => x.AuthorId == 4),
                           AuthorId = context.Authors.SingleOrDefault(x => x.AuthorId == 4).AuthorId,
                           Category = context.Categories.SingleOrDefault(x => x.CategoryId == 3),
                           CategoryId = context.Categories.SingleOrDefault(x => x.CategoryId == 3).CategoryId,
                           Price = 77,
                           ReleaseDate = new DateTime(1995, 02, 18),

                       }
                    );
                context.SaveChanges();
            }
        }
    }
}
